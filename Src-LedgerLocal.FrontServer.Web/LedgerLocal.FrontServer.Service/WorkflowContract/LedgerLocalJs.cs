using LedgerLocal.FrontServer.Service.LedgerLocalServiceContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.FrontServer.Service.WorkflowContract
{
    public class LedgerLocalJs
    {
        public LedgerLocalJs()
        {

        }

        public IAttributeService AttributeService
        {
            get
            {
                return ServiceLocatorSingleton.Instance.ServiceProvider.GetService(typeof(IAttributeService)) as IAttributeService;
            }
        }
        
        public ICustomerService CustomerService
        {
            get
            {
                return ServiceLocatorSingleton.Instance.ServiceProvider.GetService(typeof(ICustomerService)) as ICustomerService;
            }
        }
        
        public IPolicyService PolicyService
        {
            get
            {
                return ServiceLocatorSingleton.Instance.ServiceProvider.GetService(typeof(IPolicyService)) as IPolicyService;
            }
        }
        
        public IWorkflowService WorkflowService
        {
            get
            {
                return ServiceLocatorSingleton.Instance.ServiceProvider.GetService(typeof(IWorkflowService)) as IWorkflowService;
            }
        }
       
    }
}
