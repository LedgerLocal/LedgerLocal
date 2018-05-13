//using Castle.Core;
//using Castle.MicroKernel.Registration;
//using Castle.Windsor;
//using Common.Data.Infrastructure;
//using LedgerLocal.AdminServer.Data.FullDomain;
//using LedgerLocal.AdminServer.Data.FullDomain.Infrastructure;
//using LedgerLocal.AdminServer.Service;
//using LedgerLocal.AdminServer.Service.Contract;

//namespace LedgerLocal.Scheduler.Config
//{
//    public class ComponentRegistrar
//    {
//        public static void AddComponentsTo(IWindsorContainer container)
//        {
//            AddDatabaseFactoryTo(container);
//            AddGenericRepositoriesTo(container);
//            AddCustomRepositoriesTo(container);
//            AddUnitOfWorkTo(container);
//            AddServicesTo(container);
//        }

//        public static void AddDatabaseFactoryTo(IWindsorContainer container)
//        {
//            container.Register(
//                Component.For(typeof(IDatabaseFactory<BrakooEntities>))
//                    .ImplementedBy<MercuritusFullDomainDatabaseFactory>()
//                    .IsDefault()
//                    .LifestylePerThread()
//                    .Named("fullDomainDatabaseFactory"));
//        }

//        public static void AddGenericRepositoriesTo(IWindsorContainer container)
//        {
//            container.Register(
//                Component.For(typeof(IMercuritusFullDomainRepository<>))
//                    .ImplementedBy(typeof(MercuritusFullDomainRepositoryBase<>))
//                    .LifestyleTransient()
//                    .Named("fullDomainGenericRepositories"));
//        }

//        public static void AddCustomRepositoriesTo(IWindsorContainer container)
//        {
//            //container.Register(Component.For<IProductRepository>()
//            //                            .ImplementedBy<ProductRepository>()
//            //                            .LifestyleTransient());
//        }

//        public static void AddUnitOfWorkTo(IWindsorContainer container)
//        {
//            container.Register(
//                Component.For(typeof(IMercuritusFullDomainUnitOfWork))
//                    .ImplementedBy<MercuritusFullDomainUnitOfWorkBase>()
//                    .IsDefault()
//                    .LifestyleTransient()
//                    .Named("fullDomainUnitOfWork"));
//        }

//        public static void AddServicesTo(IWindsorContainer container)
//        {
//            container.Register(Component.For<IBlockChainMonitorService>()
//                                        .ImplementedBy<BlockChainMonitorService>()
//                                        .LifestyleTransient());

//            container.Register(Component.For<IDbContextService>()
//                            .ImplementedBy<DbContextService>()
//                            .LifestyleTransient());
//        }
//    }
//}
