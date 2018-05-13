using Confluent.Kafka.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LedgerLocal.Blockchain.Service.LycServiceContract
{
    public class JsonDeserializer : IDeserializer<object>
    {
        private Encoding encoding;

        public JsonDeserializer()
        {
        }

        public JsonDeserializer(Encoding encoding)
        {
            this.encoding = encoding;
        }

        public IEnumerable<KeyValuePair<string, object>> Configure(IEnumerable<KeyValuePair<string, object>> config, bool isKey)
        {
            return config;
        }

        public object Deserialize(byte[] data)
        {
            var str = encoding.GetString(data);
            return JsonConvert.DeserializeObject(str);
        }

        public object Deserialize(string topic, byte[] data)
        {
            throw new NotImplementedException();
        }
    }
}
