using Confluent.Kafka;
using LedgerLocal.Blockchain.Service.KafkaMessager;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LedgerLocal.Blockchain.Service.LycServiceContract.Architecture
{
    public interface IKafkaProducerConsumerFactory : IDisposable
    {
        KafkaConsumerSessionInfo AddConsumer(string topic, Consumer<string, string> val);

        KafkaProducerSessionInfo AddProducer(string key, Producer<string, string> val);

        KafkaConsumerSessionInfo GetConsumer(string topic);

        KafkaProducerSessionInfo GetProducer(string topic);
    }
}
