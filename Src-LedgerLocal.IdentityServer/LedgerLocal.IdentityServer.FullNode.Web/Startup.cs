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

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), opt1 => opt1.MigrationsAssembly(migrationsAssembly)));
            services.AddDbContext<PersistedGrantDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), opt1 => opt1.MigrationsAssembly(migrationsAssembly)));
            services.AddDbContext<ConfigurationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), opt1 => opt1.MigrationsAssembly(migrationsAssembly)));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // If you want to tweak Identity cookies, they're no longer part of IdentityOptions.
            services.ConfigureApplicationCookie(options => options.LoginPath = "/MemberAccount/Login");
            services.AddAuthentication();
            //.AddFacebook(options => {
            //    options.AppId = "id";
            //    options.AppSecret = "secret";
            //});

            services.AddIdentityServer()
                .AddAspNetIdentity<User>()
                .AddDeveloperSigningCredential()
                //.AddTestUsers(TestUsers.Users)
                // this adds the config data from DB (clients & resources)
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), opt1 => opt1.MigrationsAssembly(migrationsAssembly));
                })
                // this adds the operational data from DB (codes, tokens, consents)
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), opt1 => opt1.MigrationsAssembly(migrationsAssembly));

                    // this enables automatic token cleanup. this is optional.
                    options.EnableTokenCleanup = true;
                    options.TokenCleanupInterval = 30;
                });

            services.AddCors();

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

            return services.BuildServiceProvider(validateScopes: true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            _environment = env;

            // this will do the initial DB population
            //InitializeDatabase(app);

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

            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationScheme = IdentityServerConstants.DefaultCookieAuthenticationScheme,
            //    CookieName = "LLCAUTH.auth",
            //    ExpireTimeSpan = TimeSpan.FromMinutes(20),
            //    SlidingExpiration = true,
            //    AutomaticAuthenticate = true,
            //    AutomaticChallenge = true
            //});

            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationScheme = "idsrv.external", // Matches the name it's looking for in the exception
            //    AutomaticAuthenticate = true,
            //    AutomaticChallenge = true
            //});

            app.UseAuthentication();
            app.UseIdentityServer();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            //app.UseGoogleAuthentication(new GoogleOptions
            //{
            //    SignInScheme = "Identity.External",

            //    ClientId = "",
            //    ClientSecret = ""
            //});

            //app.UseFacebookAuthentication(new FacebookOptions
            //{
            //    AuthenticationScheme = "Facebook",
            //    SignInScheme = "Identity.External",
            //    AppId = "",
            //    AppSecret = ""
            //});

            //app.UseTwitterAuthentication(new TwitterOptions
            //{
            //    AuthenticationScheme = "Twitter",
            //    SignInScheme = "Identity.External",
            //    ConsumerKey = "<..>",
            //    ConsumerSecret = "<..>",
            //});

            // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715

            //app.UseClaimsTransformation(ClaimsProvider.AddClaims);

            ///
            /// Setup Custom Data Format
            /// 
            //var schemeName = "oidc";
            //var dataProtectionProvider = app.ApplicationServices.GetRequiredService<IDataProtectionProvider>();
            //var distributedCache = app.ApplicationServices.GetRequiredService<IDistributedCache>();

            //var dataProtector = dataProtectionProvider.CreateProtector(
            //    typeof(OpenIdConnectMiddleware).FullName,
            //    typeof(string).FullName, schemeName,
            //    "v1");

            //var dataFormat = new CachedPropertiesDataFormat(distributedCache, dataProtector);

            //var clientId = "<Your Client ID>";
            //var tenantId = "<Your Tenant ID>";

            //app.UseOpenIdConnectAuthentication(new OpenIdConnectOptions
            //{
            //    AuthenticationScheme = schemeName,
            //    DisplayName = "AzureAD",
            //    SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme,
            //    ClientId = clientId,
            //    Authority = $"https://login.microsoftonline.com/{tenantId}",
            //    ResponseType = OpenIdConnectResponseType.IdToken,
            //    StateDataFormat = dataFormat
            //});

            app.UseStaticFiles();

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
