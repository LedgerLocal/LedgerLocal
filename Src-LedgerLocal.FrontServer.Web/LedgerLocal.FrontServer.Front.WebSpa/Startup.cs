/*
 * LedgerLocal Server API
 *
 * LedgerLocal Server API swagger-2.0 specification
 *
 * OpenAPI spec version: 1.0.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Swashbuckle.Swagger.Model;
using Serilog;
using LedgerLocal.FrontServer.Data.FullDomain.Infrastructure;
using Common.Data.Infrastructure;
using LedgerLocal.FrontServer.Data.FullDomain;
using LedgerLocal.FrontServer.Service;
using LedgerLocal.FrontServer.Service.LedgerLocalServiceContract;
using LedgerLocal.FrontServer.Service.LedgerLocalServiceContract.Architecture;
using LedgerLocal.FrontServer.Service.KafkaMessager.Contract;
using LedgerLocal.FrontServer.Service.KafkaMessager;
using LedgerLocal.FrontServer.Service.WorkflowContract;
using LedgerLocal.FrontServer.Service.WorkflowImpl;
using AutoMapper;
using LedgerLocal.FrontServer.Service.PersistenceService;
using System.Globalization;
using LedgerLocal.FrontServer.Service.Contract;
using LedgerLocal.FrontServer.Data.FullDomain.Bulk;
using Microsoft.AspNetCore.SpaServices.Webpack;

namespace LedgerLocal.FrontServer.Api.Web
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnv;

        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            _hostingEnv = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
            Configuration = builder.Build();

            //var seqServerUrl = Configuration["SeqServer"];
            Serilog.Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                //.WriteTo.Seq(seqServerUrl)
                .CreateLogger();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            //dependency injection

            var connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                connectionString = "Host=91.121.107.37;Database=ledgerlocaldb;Username=lladmin;Password=ll132@;Port=5432";
            }

            //EF
            services.AddScoped(typeof(IDatabaseFactory<LedgerLocalDbContext>), _ => new LedgerLocalDbFullDomainDatabaseFactory(connectionString));

            services.AddScoped(typeof(ILedgerLocalDbFullDomainRepository<>), typeof(LedgerLocalDbFullDomainRepositoryBase<>));

            services.AddScoped(typeof(ILedgerLocalDbFullDomainUnitOfWork), typeof(LedgerLocalDbFullDomainUnitOfWorkBase));

            services.AddSingleton(typeof(MapperConfiguration), MappingRegistrar.CreateMapperConfig());

            services.AddTransient(typeof(ILedgerLocalBulkOperator), typeof(LedgerLocalBulkOperator));

            //Services
            var kafkaUrl = Configuration["Kafka"];
            
            services.AddTransient(typeof(IDbContextService), typeof(DbContextService));

            services.AddTransient(typeof(ICustomerService), typeof(CustomerService));

            services.AddTransient(typeof(IAttributeService), typeof(AttributeService));

            
            

            services.AddTransient(typeof(IWorkflowService), typeof(WorkflowService));

           
            services.AddTransient(typeof(IWorkflowRunnerService), typeof(WorkflowRunnerService));

            // Add framework services.
            services.AddMvc()
                .AddJsonOptions(
                    opts => { opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); });
            
            services.AddSwaggerGen();
            
            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "LedgerLocal.FrontServer.Api.Web",
                    Description = "LedgerLocal.FrontServer.Api.Web (ASP.NET Core 2.0)"
                });

                options.DescribeAllEnumsAsStrings();

                //var comments = new XPathDocument($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{_hostingEnv.ApplicationName}.xml");
                //options.OperationFilter<XmlCommentsOperationFilter>(comments);
                //options.ModelFilter<XmlCommentsModelFilter>(comments);
            });

            var sp = services.BuildServiceProvider();
            ServiceLocatorSingleton.Instance.ServiceProvider = sp;

            //var exBuffer = sp.GetService<IExchangeBufferRunner>();
            //exBuffer.Start();

            return sp;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime appLifetime)
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
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });

            app.UseSwagger();
            app.UseSwaggerUi();
           
        }
    }
}
