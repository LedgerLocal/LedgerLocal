using Confluent.Kafka;
using LedgerLocal.AdminServer.Service.KafkaMessager.KafkaReactive;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.Blockchain.Service.KafkaMessager
{
    public class KafkaProducerSessionInfo
    {
        public Producer<string, string> Producer { get; set; }

        public BlockingCollection<Record<string, string>> ProducerBlockingQueue { get; set; }
    }
}
