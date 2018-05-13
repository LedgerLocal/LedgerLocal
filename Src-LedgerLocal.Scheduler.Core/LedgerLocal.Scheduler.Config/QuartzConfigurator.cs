//using System.Configuration;
//using Alphacloud.Common.ServiceLocator.Castle;
//using Castle.Windsor;
//using Microsoft.Practices.ServiceLocation;
//using Quartz.Job;
//using LedgerLocal.AdminServer.Jobs;
//using LedgerLocal.Scheduler.Config;

//namespace LedgerLocal.Scheduler.Application
//{
//    public class QuartzConfigurator
//    {
//        public QuartzConfigurator()
//        {
//            //_mappingRegistrar = new MappingRegistrar();
//        }

//        public void InitializeMappings()
//        {
//            MappingRegistrar.AddMapping();
//        }

//        public IWindsorContainer InitializeWindsorContainer()
//        {
//            IWindsorContainer windsorContainer = new WindsorContainer();

//            ComponentRegistrar.AddComponentsTo(windsorContainer);

//            windsorContainer.RegisterQuartzJobs(typeof(DummyJob).Assembly);
//            windsorContainer.RegisterQuartzJob<FileScanJob>();

//            var wServiceLocator = new WindsorServiceLocatorAdapter(windsorContainer);
//            ServiceLocator.SetLocatorProvider(() => wServiceLocator);

//            return windsorContainer;
//        }

//        public void InitializeNHibernateSession()
//        {
//            //_sessionManager.NHibernateSessionInitialization();
//        }
//    }
//}
