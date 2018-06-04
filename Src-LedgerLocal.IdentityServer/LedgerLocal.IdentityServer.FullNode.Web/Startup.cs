using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using UserManagement.Models;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using IdentityServer4.Quickstart.UI;
using LedgerLocal.IdentityServer.FullNode.Web.Data;
using LedgerLocal.IdentityServer.FullNode.Web.Services;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.DataProtection;
using System.IO;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Serilog;

namespace LedgerLocal.IdentityServer.FullNode.Web
{
    public class Startup
    {
        private IHostingEnvironment _environment;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            _environment = env;

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();

            Configuration = Program.MainConfig;
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            Serilog.Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .WriteTo.Seq(Configuration["SeqServer"])
                .CreateLogger();

            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), opt1 => opt1.MigrationsAssembly(migrationsAssembly)));
            services.AddDbContext<PersistedGrantDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), opt1 => opt1.MigrationsAssembly(migrationsAssembly)));
            services.AddDbContext<ConfigurationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), opt1 => opt1.MigrationsAssembly(migrationsAssembly)));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication();
            //.AddFacebook(options => {
            //    options.AppId = "id";
            //    options.AppSecret = "secret";
            //});

            var id1 = services.AddIdentityServer()
                .AddDefaultEndpoints()
                .AddAspNetIdentity<User>();

            if (_environment != null && _environment.IsDevelopment())
            {
                id1 = id1.AddDeveloperSigningCredential()
                    .AddTestUsers(TestUsers.Users);
            }
            else
            {
                var cert = new X509Certificate2(Configuration["PathCert"], Configuration["PasswordCert"]);
                id1 = id1.AddSigningCredential(cert);
            }
            
            id1
                // this adds the config data from DB (clients & resources)
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                        builder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), opt1 => opt1.MigrationsAssembly(migrationsAssembly));
                })
                // this adds the operational data from DB (codes, tokens, consents)
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                        builder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), opt1 => opt1.MigrationsAssembly(migrationsAssembly));

                    // this enables automatic token cleanup. this is optional.
                    options.EnableTokenCleanup = true;
                    options.TokenCleanupInterval = 30;
                });

            // ********************
            // Setup CORS
            // ********************
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin(); // For anyone access.
            //corsBuilder.WithOrigins("http://localhost:56573"); // for a specific url. Don't add a forward slash on the end!
            corsBuilder.AllowCredentials();

            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            });

            services.AddMvc();

            //// only want this during testing
            //if (_env.IsDevelopment())
            //{
            //    //EnsureSeedData(services);
            //}

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 2;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                options.LoginPath = "/MemberAccount/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                options.LogoutPath = "/MemberAccount/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                options.AccessDeniedPath = "/MemberAccount/AccessDenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                options.SlidingExpiration = true;
            });

            // Add application services.
            services.AddTransient<AccountService, AccountService>();
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            services.Configure<AuthMessageSenderOptions>(Configuration);
            services.Configure<CertificateOptions>(Configuration);

            return services.BuildServiceProvider(validateScopes: true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime appLifetime, IServiceProvider serviceProvider)
        {
            _environment = env;

            // this will do the initial DB population
            InitializeDatabase(app);

            loggerFactory.AddSerilog();
            appLifetime.ApplicationStopped.Register(Serilog.Log.CloseAndFlush);

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseStaticFiles();

            
            app.UseIdentityServer();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //ApplicationDbContextSeed.Seed(app.ApplicationServices).Wait();
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                context.Database.Migrate();
                if (!context.Clients.Any())
                {
                    foreach (var client in Config.GetClients())
                    {
                        context.Clients.Add(client.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.IdentityResources.Any())
                {
                    foreach (var resource in Config.GetIdentityResources())
                    {
                        context.IdentityResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.ApiResources.Any())
                {
                    foreach (var resource in Config.GetApiResources())
                    {
                        context.ApiResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
