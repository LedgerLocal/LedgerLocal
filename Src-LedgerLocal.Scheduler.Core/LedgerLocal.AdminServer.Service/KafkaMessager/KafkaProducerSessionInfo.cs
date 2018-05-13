using Confluent.Kafka;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.AdminServer.Service.KafkaMessager
{
    public class KafkaProducerSessionInfo<T>
    {
        public Producer<string, T> Producer { get; set; }
    }
}
