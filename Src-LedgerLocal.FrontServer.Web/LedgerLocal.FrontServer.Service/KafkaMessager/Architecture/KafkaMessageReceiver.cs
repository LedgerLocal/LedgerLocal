using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.Blockchain.Service.LycServiceContract.Architecture
{
    public class KafkaMessageReceiver<T>
        where T : class
    {
        public KafkaMessageReceiver()
        {
        }

        public string Key { get; set; }

        public string TopicName { get; set; }

        public object InstanceContent { get; set; }

        public T Instance {
            get
            {
                var jsonString = JsonConvert.SerializeObject(InstanceContent);
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
        }
    }
}
