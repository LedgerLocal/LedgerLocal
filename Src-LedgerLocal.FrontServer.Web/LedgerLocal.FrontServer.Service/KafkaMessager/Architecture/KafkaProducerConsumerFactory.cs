using System;
using System.Collections.Generic;
using System.Text;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;
using LedgerLocal.Blockchain.Service.KafkaMessager;
using LedgerLocal.AdminServer.Service.KafkaMessager.KafkaReactive;

namespace LedgerLocal.Blockchain.Service.LycServiceContract.Architecture
{
    public class KafkaProducerConsumerFactory : IKafkaProducerConsumerFactory
    {
        private ConcurrentDictionary<string, KafkaConsumerSessionInfo> _dicoConsumer;
        private ConcurrentDictionary<string, KafkaProducerSessionInfo> _dicoProducer;

        private readonly IKafkaConfigFactory _kafkaConfig;

        public KafkaProducerConsumerFactory(IKafkaConfigFactory kafkaConfig)
        {
            _kafkaConfig = kafkaConfig;
            _dicoConsumer = new ConcurrentDictionary<string, KafkaConsumerSessionInfo>();
            _dicoProducer = new ConcurrentDictionary<string, KafkaProducerSessionInfo>();
        }
        
        public KafkaConsumerSessionInfo AddConsumer(string topic, Consumer<string, string> val)
        {
            var clientBc = new BlockingCollection<Try<Record<string, string>>>();
            var obsClient = clientBc
                .GetConsumingEnumerable()
                .ToObservable(Scheduler.Default);
            obsClient.Buffer(TimeSpan.FromSeconds(1), 5);

            var session = new KafkaConsumerSessionInfo
            {
                Consumer = val,
                ObserverPublic = obsClient,
                BlockingCollentionPublic = clientBc
            };

            val.OnMessage += (obj, mess) =>
            {
                if (!mess.Error.HasError)
                {
                    var rec = new Record<string, string>(mess.Key, mess.Value);
                    rec.MessageRaw = mess;
                    var successMsg = new Success<Record<string, string>>(rec);
                    clientBc.Add(successMsg);
                    session.RaiseEvent(new KafkaEventArgs() { Record = successMsg });
                }
            };

            val.Subscribe(topic);

            session.PollingSub = Task.Run(() =>
            {

                while (true)
                {
                    val.Poll(500);
                }
                
            });

            if (_dicoConsumer.TryAdd(topic, session))
            {
                return session;
            }

            return null;
        }

        public KafkaProducerSessionInfo AddProducer(string topic, Producer<string, string> val)
        {
            var utcNow = DateTime.UtcNow;
            var bc = new BlockingCollection<Record<string, string>>();

            bc.GetConsumingEnumerable()
                .ToObservable(Scheduler.Default)
                .Buffer(TimeSpan.FromSeconds(1), 5)
                .Subscribe(async (a) =>
                {
                    if (!(a != null && a.Count > 0))
                    {
                        return;
                    }

                    foreach(var item in a)
                    {
                        await Task.Factory.StartNew(() => {
                            var msg = val.ProduceAsync(topic, item.Key, item.Value).Result;

                            if (msg.Error.HasError)
                            {
                                throw new Exception($"Failed Send Message: {msg.Error.Code}: {msg.Error.Reason}");
                            }

                        });
                    }
                });

            var session = new KafkaProducerSessionInfo
            {
                Producer = val,
                ProducerBlockingQueue = bc
            };

            if ( _dicoProducer.TryAdd(topic, session))
            {
                return session;
            }

            return null;
        }

        public KafkaConsumerSessionInfo GetConsumer(string topic)
        {
            KafkaConsumerSessionInfo res;
            if (_dicoConsumer.TryGetValue(topic, out res))
            {
                return res;
            }

            return CreateConsumer(topic);
        }

        public KafkaProducerSessionInfo GetProducer(string topic)
        {
            KafkaProducerSessionInfo res;
            if (_dicoProducer.TryGetValue(topic, out res))
            {
                return res;
            }

            return CreateProducer(topic);
        }

        private Dictionary<string, object> constructConfig(string brokerList, bool enableAutoCommit) =>
            new Dictionary<string, object>
            {
                { "group.id", $"lyc-kafka-frontc-deamon-{Thread.CurrentThread.ManagedThreadId}" },
                { "enable.auto.commit", enableAutoCommit },
                { "auto.commit.interval.ms", 5000 },
                { "statistics.interval.ms", 60000 },
                { "bootstrap.servers", brokerList },
                { "default.topic.config", new Dictionary<string, object>()
                    {
                        { "auto.offset.reset", "smallest" }
                    }
                }
            };

        private KafkaConsumerSessionInfo CreateConsumer(string topicName)
        {
            var c = new Consumer<string, string>(constructConfig(_kafkaConfig.BrokerList, _kafkaConfig.EnableAutoCommit),
                            new StringDeserializer(Encoding.UTF8),
                            new StringDeserializer(Encoding.UTF8));

            var session = AddConsumer(topicName, c);
            return session;
        }

        private KafkaProducerSessionInfo CreateProducer(string topicName)
        {
            var conf = new Dictionary<string, object>
                    {
                        { "group.id", $"lyc-kafka-frontp-deamon-{Thread.CurrentThread.ManagedThreadId}" },
                        { "bootstrap.servers", _kafkaConfig.BrokerList }
                    };

            var p = new Producer<string, string>(conf,
                            new StringSerializer(Encoding.UTF8),
                            new StringSerializer(Encoding.UTF8));

            var session = AddProducer(topicName, p);
            return session;
        }

        public void Dispose()
        {
            
        }
    }
}
