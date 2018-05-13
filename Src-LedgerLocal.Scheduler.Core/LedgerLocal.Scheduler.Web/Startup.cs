using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

using Quartz.Impl;
using Quartz.Impl.Calendar;
using Swashbuckle.Swagger.Model;
using Serilog;
using AutoMapper;
using Telegram.Bot;
using LedgerLocal.AdminServer.Service.BusinessImplService.Contract;
using LedgerLocal.AdminServer.Service.BusinessImplService;
using LedgerLocal.AdminServer.Service;
using LedgerLocal.Scheduler.Core;
using LedgerLocal.AdminServer.Jobs;
//using Quartz.Web.LiveLog;

namespace Quartz.Web
{

    public class Startup
    {
        //public IConfigurationRoot Configuration { get; }

        private readonly IHostingEnvironment _hostingEnv;

        public IConfigurationRoot Configuration { get; }

        public bool IsDebugEnv { get; set; } = false;

        public Startup(IHostingEnvironment env)
        {
            _hostingEnv = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            Configuration = builder.Build();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .WriteTo.Seq("http://sphebot.appswiss.ch:5132")
                .CreateLogger();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            var now = DateTime.UtcNow;

            var gConf = new GlobalConfig()
            {
                SeqServer = "",
                EsUrl = ""
            };
            
            var tBot = new TelegramBotClient("");

            var telegramClient = new TelegramClientFactory();
            telegramClient.AdminClient = tBot;
            telegramClient.PublicClient = tBot;
            
            services.AddLogging();

            services.AddSingleton(typeof(IGlobalConfig), gConf);

            services.AddSingleton(typeof(MapperConfiguration), MappingRegistrar.CreateMapperConfig());

            //services.AddSingleton(typeof(IElasticClient), new ElasticClient(new Uri("http://.appswiss.ch:9200")));

            services.AddTransient(typeof(IRdfStoreBusiness), typeof(RdfStoreBusiness));

            services.AddTransient(typeof(IRunningStatBusiness), typeof(RunningStatBusiness));

            services.AddTransient(typeof(IElasticBusiness), typeof(ElasticBusiness));

            services.AddSingleton(typeof(ITelegramBotClient), tBot);

            services.AddSingleton(typeof(ITelegramClientFactory), telegramClient);

            services.AddSingleton(typeof(IBotService), typeof(BotService));

            services.AddTransient(typeof(DummyJob), typeof(DummyJob));

            services.AddTransient(typeof(StatPoolingJob), typeof(StatPoolingJob));

            services.AddTransient(typeof(TelegramAdminJob), typeof(TelegramAdminJob));
            
            // Add framework services.
            services.AddMvc()
                .AddJsonOptions(
                    opts => { opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); });

            //call this in case you need aspnet-user-authtype/aspnet-user-identity
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            services.AddSwaggerGen();

            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "Quartz.Web API",
                    Description = "Quartz.Web API"
                });

                options.DescribeAllEnumsAsStrings();

                //var comments = new XPathDocument($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{_hostingEnv.ApplicationName}.xml");
                //options.OperationFilter<XmlCommentsOperationFilter>(comments);
                //options.ModelFilter<XmlCommentsModelFilter>(comments);
            });

            var sp = ConfigureQuartz(services);

            return sp;

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime appLifetime, IServiceProvider serviceProvider)
        {

            loggerFactory.AddSerilog();
            appLifetime.ApplicationStopped.Register(Log.CloseAndFlush);

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseSwagger();
            app.UseSwaggerUi();

            
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }


        private IServiceProvider ConfigureQuartz(IServiceCollection services)
        {
            
            // First we must get a reference to a scheduler
            ISchedulerFactory sf = new StdSchedulerFactory();
            IScheduler scheduler = sf.GetScheduler().Result;

            var sp1 = services.BuildServiceProvider();

            scheduler.JobFactory = new DiJobFactory(sp1);

            // var liveLogPlugin = new LiveLogPlugin();
            // scheduler.ListenerManager.AddJobListener(liveLogPlugin);
            // scheduler.ListenerManager.AddTriggerListener(liveLogPlugin);
            // scheduler.ListenerManager.AddSchedulerListener(liveLogPlugin);

            scheduler.AddCalendar(typeof (AnnualCalendar).Name, new AnnualCalendar(), false, false);
            scheduler.AddCalendar(typeof (CronCalendar).Name, new CronCalendar("0 0/5 * * * ?"), false, false);
            scheduler.AddCalendar(typeof (DailyCalendar).Name, new DailyCalendar("12:01", "13:04"), false, false);
            scheduler.AddCalendar(typeof (HolidayCalendar).Name, new HolidayCalendar(), false, false);
            scheduler.AddCalendar(typeof (MonthlyCalendar).Name, new MonthlyCalendar(), false, false);
            //scheduler.AddCalendar(typeof (WeeklyCalendar).Name, new WeeklyCalendar(), false, false);

            services.AddSingleton<IScheduler>(scheduler);
            scheduler.Start();

            return sp1;
        }
    }

}