//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Castle.Windsor;
//using Microsoft.AspNet.SignalR.Hubs;

//namespace LedgerLocal.Common.Web.Mvc
//{
//    public class CastleHubActivator : IHubActivator
//    {
//        private readonly IWindsorContainer _container;

//        public CastleHubActivator(IWindsorContainer container)
//        {
//            _container = container;
//        }

//        public IHub Create(HubDescriptor descriptor)
//        {
//            return _container.Resolve(descriptor.HubType) as IHub;
//        }
//    }
//}
