using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using LedgerLocal.FrontServer.Service.KafkaMessager;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LedgerLocal.FrontServer.Service.LedgerLocalServiceContract.Architecture
{
    public interface IKafkaProducerConsumerFactory<T> : IDisposable
    {
        KafkaConsumerSessionInfo<T> AddConsumer(string sessionid, string topic, TimeSpan delayFps, Consumer<string, T> val);

        KafkaProducerSessionInfo<T> AddProducer(string key, Producer<string, T> val);

        KafkaConsumerSessionInfo<T> GetConsumer(string sessionid, string topic, TimeSpan delayFps, IDeserializer<T> deserializer);

        KafkaProducerSessionInfo<T> GetProducer(string topic, ISerializer<T> serializer);
    }
}
