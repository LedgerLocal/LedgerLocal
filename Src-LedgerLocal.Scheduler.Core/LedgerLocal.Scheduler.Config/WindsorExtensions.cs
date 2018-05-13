//using Castle.Core;
//using Castle.MicroKernel.Registration;
//using Castle.Windsor;
//using LedgerLocal.Scheduler.Config;
//using Quartz;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Web;

//namespace LedgerLocal.Scheduler.Application
//{
//    public static class WindsorExtensions
//    {
//        public static IWindsorContainer RegisterQuartzJob<T>(this IWindsorContainer container) where T : IJob
//        {
//            container.RegisterQuartzJobs(typeof(T));
//            return container;
//        }

//        public static IWindsorContainer RegisterQuartzJobs(this IWindsorContainer container, params Type[] jobTypes)
//        {
//            foreach (var type in jobTypes)
//            {
//                if (JobExtensions.IsJob(type))
//                {
//                    container.AddComponentLifeStyle(type.FullName.ToLower(), type, LifestyleType.Transient);
//                }
//            }

//            return container;
//        }

//        public static IWindsorContainer RegisterQuartzJobs(this IWindsorContainer container, params Assembly[] assemblies)
//        {
//            foreach (var assembly in assemblies)
//            {
//                container.RegisterQuartzJobs(assembly.GetExportedTypes());
//            }
//            return container;
//        }

//        public static BasedOnDescriptor FirstNonGenericCoreInterface(this ServiceDescriptor descriptor, string interfaceNamespace)
//        {
//            var allInterface = descriptor.AllInterfaces();

//            var filtered = allInterface.If(type =>
//            {
//                var interfaces = type.GetInterfaces()
//                    .Where(t => t.IsGenericType == false && t.Namespace.StartsWith(interfaceNamespace));

//                if (interfaces.Count() > 0)
//                {
//                    return true;
//                }

//                return false;
//            });

//            return filtered;
//        }
//    }
//}