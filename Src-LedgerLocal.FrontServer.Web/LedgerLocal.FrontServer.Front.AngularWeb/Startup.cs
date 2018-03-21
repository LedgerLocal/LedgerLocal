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
using LedgerLocal.FrontServer.Dto;
using LedgerLocal.FrontServer.Service;
using LedgerLocal.FrontServer.Service.BusinessImplService;
using LedgerLocal.FrontServer.Service.BusinessImplService.Contract;
using LedgerLocal.FrontServer.Service.Contract;
using LedgerLocal.FrontServer.Service.PersistenceService;
using LedgerLocal.FrontServer.Service.WorkflowContract;
using LedgerLocal.FrontServer.Service.WorkflowImpl;

namespace LedgerLocal.FrontServer.Front.AngularWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //dependency injection

            var connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                connectionString = "Host=91.121.107.37;Database=ledgerlocaldb;Username=llcadmin;Password=llc132@;Port=5432";
            }

            //EF
            services.AddScoped(typeof(IDatabaseFactory<LedgerLocalDbContext>), _ => new LedgerLocalDbFullDomainDatabaseFactory(connectionString));

            services.AddScoped(typeof(ILedgerLocalDbFullDomainRepository<>), typeof(LedgerLocalDbFullDomainRepositoryBase<>));

            services.AddScoped(typeof(ILedgerLocalDbFullDomainUnitOfWork), typeof(LedgerLocalDbFullDomainUnitOfWorkBase));

            services.AddSingleton(typeof(MapperConfiguration), MappingRegistrar.CreateMapperConfig());

            services.AddTransient(typeof(ILedgerLocalBulkOperator), typeof(LedgerLocalBulkOperator));

            services.AddTransient(typeof(IDbContextService), typeof(DbContextService));

            services.AddTransient(typeof(IAttributeService), typeof(AttributeService));

            services.AddTransient(typeof(IWorkflowService), typeof(WorkflowService));

            services.AddTransient(typeof(IGenericCrudService<,>), typeof(GenericCrudService<,>));
            
            services.AddTransient(typeof(IWorkflowRunnerService), typeof(WorkflowRunnerService));

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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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

            app.UseMvc(routes =>
            {
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
