using AutoMapper;
using Common.Data.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.Swagger.Model;
using LedgerLocal.FrontServer.Data.FullDomain;
using LedgerLocal.FrontServer.Data.FullDomain.Bulk;
using LedgerLocal.FrontServer.Data.FullDomain.Infrastructure;
using LedgerLocal.FrontServer.Service;
using LedgerLocal.FrontServer.Service.BusinessImplService;
using LedgerLocal.FrontServer.Service.BusinessImplService.Contract;
using LedgerLocal.FrontServer.Service.Contract;
using LedgerLocal.FrontServer.Service.PersistenceService;
using LedgerLocal.Blockchain.Service.LycServiceContract;
using LedgerLocal.Blockchain.Service.LycServiceContract.Architecture;
using LedgerLocal.Blockchain.Service.KafkaMessager;
using LedgerLocal.Blockchain.Service.KafkaMessager.Contract;
using Serilog;
using System.Globalization;
using Microsoft.Extensions.Logging;
using System;

namespace LedgerLocal.FrontServer.Front.AngularWeb
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnv;

        public IConfigurationRoot Configuration { get; }

        public bool IsDebugEnv { get; set; } = false;

        public Startup(IHostingEnvironment env)
        {
            _hostingEnv = env;

            Configuration = Program.MainConfig;
            
            Serilog.Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .WriteTo.Seq(Configuration["SeqServer"])
                .CreateLogger();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();

            //dependency injection

            var connectionString = Configuration["ConnString"];

            //EF
            services.AddScoped(typeof(IDatabaseFactory<LedgerLocalDbContext>), _ => new LedgerLocalDbFullDomainDatabaseFactory(connectionString));

            services.AddScoped(typeof(ILedgerLocalDbFullDomainRepository<>), typeof(LedgerLocalDbFullDomainRepositoryBase<>));

            services.AddScoped(typeof(ILedgerLocalDbFullDomainUnitOfWork), typeof(LedgerLocalDbFullDomainUnitOfWorkBase));

            services.AddSingleton(typeof(MapperConfiguration), MappingRegistrar.CreateMapperConfig());

            //Services
            var kafkaUrl = Configuration["Kafka"];
            services.AddSingleton(typeof(IKafkaConfigFactory), _ => new KafkaConfigFactory(kafkaUrl));

            services.AddSingleton(typeof(IKafkaProducerConsumerFactory), typeof(KafkaProducerConsumerFactory));
            services.AddSingleton(typeof(IKafkaFacade), typeof(KafkaFacade));

            services.AddTransient(typeof(ICommonMessageService), typeof(CommonMessageService));

            services.AddTransient(typeof(ILedgerLocalBulkOperator), typeof(LedgerLocalBulkOperator));

            services.AddTransient(typeof(IDbContextService), typeof(DbContextService));

            services.AddTransient(typeof(IAttributeService), typeof(AttributeService));

            services.AddTransient(typeof(IGenericCrudService<,>), typeof(GenericCrudService<,>));

            services.AddMvc();

            // ********************
            // Setup CORS
            // ********************
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin(); // For anyone access.
            corsBuilder.AllowCredentials();

            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            });

            services.AddSignalR();

            services.AddSwaggerGen();

            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "Torque.FrontServer.Front.Api",
                    Description = "Torque.FrontServer.Front.Api (ASP.NET Core 2.0)"
                });

                options.DescribeAllEnumsAsStrings();

                //var comments = new XPathDocument($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{_hostingEnv.ApplicationName}.xml");
                //options.OperationFilter<XmlCommentsOperationFilter>(comments);
                //options.ModelFilter<XmlCommentsModelFilter>(comments);
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime appLifetime, IServiceProvider serviceProvider)
        {
            var cultureInfo = new CultureInfo("en-US");

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            loggerFactory.AddSerilog();
            appLifetime.ApplicationStopped.Register(Serilog.Log.CloseAndFlush);

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUi();

            app.UseCors("SiteCorsPolicy");

            app.UseSignalR(routes =>
            {
                routes.MapHub<LedgerLocalHub>("/rtllc");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute("siglyccurs", "rtllc/*");
                routes.MapRoute("siglyc", "rtllc");

                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
