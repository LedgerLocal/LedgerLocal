using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.AdminServer.Service
{
    public class ServiceLocatorSingleton
    {
        private static readonly Lazy<ServiceLocatorSingleton> _lazy =
        new Lazy<ServiceLocatorSingleton>(() => new ServiceLocatorSingleton());

        private ServiceLocatorSingleton()
        {
            Console.WriteLine("Instance created");
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public static ServiceLocatorSingleton Instance
        {
            get
            {
                return _lazy.Value;
            }
        }

        public IServiceProvider ServiceProvider { get; set; }
        public DateTime UtcStartDate { get; set; }
    }
}
