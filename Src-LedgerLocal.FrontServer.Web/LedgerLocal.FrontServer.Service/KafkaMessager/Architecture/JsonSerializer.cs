using Confluent.Kafka.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LedgerLocal.Blockchain.Service.LycServiceContract
{
    public class JsonSerializer : ISerializer<object>
    {
        private Encoding encoding;

        public JsonSerializer(Encoding encoding)
        {
            this.encoding = encoding;
        }

        public IEnumerable<KeyValuePair<string, object>> Configure(IEnumerable<KeyValuePair<string, object>> config, bool isKey)
        {
            return config;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public byte[] Serialize(object data)
        {
            var str = JsonConvert.SerializeObject(data);
            return encoding.GetBytes(str);
        }

        public byte[] Serialize(string topic, object data)
        {
            throw new NotImplementedException();
        }
    }
}
