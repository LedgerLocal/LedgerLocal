using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.Blockchain.Service.LycServiceContract
{
    public class CommonMessageEncapsulator<T>
        where T : class
    {
        private readonly T _instance;

        public CommonMessageEncapsulator(T instance)
        {
            _instance = instance;
        }

        public T InstanceContent
        {
            get { return _instance; }
        }

        public string Key { get; set; }

        public string TopicName { get; set; }

        public DateTime ExecutionDate
        {
            get { return DateTime.UtcNow; }
        }
    }
}
