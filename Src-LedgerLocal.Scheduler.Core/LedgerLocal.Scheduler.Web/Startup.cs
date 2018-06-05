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
using LedgerLocal.Blockchain.Service.LycServiceContract;
using LedgerLocal.Blockchain.Service.LycServiceContract.Architecture;
using LedgerLocal.Blockchain.Service.KafkaMessager.Contract;
using LedgerLocal.Blockchain.Service.KafkaMessager;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Globalization;
using LedgerLocal.AdminServer.Service.LycServiceImpl;
using LedgerLocal.AdminServer.Service.LycServiceContract;
using System.IO;
using LedgerLocal.AdminServer.Service.Contract;
using LedgerLocal.Service.GrapheneLogic;
using LedgerLocal.Service.ChainService;
using Common.Data.Infrastructure;
using LedgerLocal.AdminServer.Data.FullDomain.Infrastructure;
using LedgerLocal.AdminServer.Data.FullDomain;
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

            Configuration = Program.MainConfig;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            var now = DateTime.UtcNow;

            Serilog.Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .WriteTo.Seq(Configuration["SeqServer"])
                .CreateLogger();

            var connectionString = Configuration["ConnString"];

            //EF
            services.AddScoped(typeof(IDatabaseFactory<LedgerLocalDbContext>), _ => new LedgerLocalDbFullDomainDatabaseFactory(connectionString));

            services.AddScoped(typeof(ILedgerLocalDbFullDomainRepository<>), typeof(LedgerLocalDbFullDomainRepositoryBase<>));

            services.AddScoped(typeof(ILedgerLocalDbFullDomainUnitOfWork), typeof(LedgerLocalDbFullDomainUnitOfWorkBase));

            services.AddTransient(typeof(IDbContextService), typeof(DbContextService));

            var gConf = new GlobalConfig()
            {
                SeqServer = Configuration["SeqServer"],
                EsUrl = ""
            };
            
            var tBot = new TelegramBotClient(Configuration["TelegramKey"]);

            var telegramClient = new TelegramClientFactory();
            telegramClient.AdminClient = tBot;
            telegramClient.PublicClient = tBot;
            
            services.AddLogging();

            services.AddSingleton(typeof(IGlobalConfig), gConf);

            var gws1 = Configuration["GrapheneBlockWs"];
            var gws2 = Configuration["GrapheneWalletWs"];

            var gc1 = new GrapheneConfig(gws1, gws2);
            services.AddSingleton(typeof(IGrapheneConfig), _ => gc1);

            //Services
            var kafkaUrl = Configuration["Kafka"];
            services.AddSingleton(typeof(IKafkaConfigFactory), _ => new KafkaConfigFactory(kafkaUrl));

            services.AddSingleton(typeof(IKafkaProducerConsumerFactory), typeof(KafkaProducerConsumerFactory));
            services.AddSingleton(typeof(IKafkaFacade), typeof(KafkaFacade));

            services.AddTransient(typeof(ICommonMessageService), typeof(CommonMessageService));

            services.AddSingleton(typeof(MapperConfiguration), MappingRegistrar.CreateMapperConfig());

            //services.AddSingleton(typeof(IElasticClient), new ElasticClient(new Uri("http://octopus.appswiss.ch:9200")));

            services.AddTransient(typeof(IRdfStoreBusiness), typeof(RdfStoreBusiness));

            services.AddTransient(typeof(IRunningStatBusiness), typeof(RunningStatBusiness));

            services.AddTransient(typeof(IElasticBusiness), typeof(ElasticBusiness));

            services.AddTransient(typeof(IKafkaEventService), typeof(KafkaEventService));

            services.AddTransient(typeof(IBlockTradeService), typeof(BlockTradeService));

            services.AddSingleton(typeof(ITelegramBotClient), tBot);

            services.AddSingleton(typeof(ITelegramClientFactory), telegramClient);

            services.AddSingleton(typeof(IBotService), typeof(BotService));

            services.AddSingleton(typeof(IWebSocketClientFactory), typeof(WebSocketClientFactory));

            services.AddTransient(typeof(IAssetService), typeof(AssetService));

            services.AddTransient(typeof(IAccountService), typeof(AccountService));

            services.AddTransient(typeof(ILimitOrderService), typeof(LimitOrderService));

            services.AddTransient(typeof(IGenericCrudService<,>), typeof(GenericCrudService<,>));

            services.AddTransient(typeof(IParticipateBusinessService), typeof(ParticipateBusinessService));
            

            //Job
            services.AddTransient(typeof(DummyJob), typeof(DummyJob));

            services.AddTransient(typeof(StatPoolingJob), typeof(StatPoolingJob));

            services.AddTransient(typeof(TelegramAdminJob), typeof(TelegramAdminJob));

            services.AddTransient(typeof(KafkaListenerJob), typeof(KafkaListenerJob));

            services.AddTransient(typeof(AccountListenerJob), typeof(AccountListenerJob));


            // Add framework services.
            services.AddMvc()
                .AddJsonOptions(
                    opts => { opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); });

            //call this in case you need aspnet-user-authtype/aspnet-user-identity
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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

            ServiceLocatorSingleton.Instance.ServiceProvider = sp;
            ServiceLocatorSingleton.Instance.UtcStartDate = DateTime.UtcNow;

            return sp;

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

            app.UseSwagger();
            app.UseSwaggerUi();

            app.UseMvc();
            app.UseCors("SiteCorsPolicy");

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