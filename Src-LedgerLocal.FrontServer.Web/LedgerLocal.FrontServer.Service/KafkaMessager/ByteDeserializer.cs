using Confluent.Kafka.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.FrontServer.Service.KafkaMessager
{
    public class ByteDeserializer : IDeserializer<byte[]>
    {
        public ByteDeserializer()
        {
        }

        public IEnumerable<KeyValuePair<string, object>> Configure(IEnumerable<KeyValuePair<string, object>> config, bool isKey)
        {
            return config;
        }

        public byte[] Deserialize(byte[] data)
        {
            return data;
        }

        public byte[] Deserialize(string topic, byte[] data)
        {
            return data;
        }

        public void Dispose()
        {
        }
    }
}
