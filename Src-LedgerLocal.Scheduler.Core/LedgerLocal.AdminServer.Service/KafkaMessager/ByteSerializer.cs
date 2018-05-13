using Confluent.Kafka.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.FrontServer.Service.KafkaMessager
{
    public class ByteSerializer : ISerializer<byte[]>
    {
        public IEnumerable<KeyValuePair<string, object>> Configure(IEnumerable<KeyValuePair<string, object>> config, bool isKey)
        {
            return config;
        }

        public byte[] Serialize(byte[] data)
        {
            return data;
        }

        public byte[] Serialize(string topic, byte[] data)
        {
            throw new NotImplementedException();
        }
    }
}
