using Confluent.Kafka;
using LedgerLocal.AdminServer.Service.KafkaMessager.KafkaReactive;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LedgerLocal.Blockchain.Service.KafkaMessager
{
    public class KafkaConsumerSessionInfo
    {
        public Consumer<string, string> Consumer { get; set; }

        public IObservable<Try<Record<string, string>>> ObserverPublic { get; set; }

        public BlockingCollection<Try<Record<string, string>>> BlockingCollentionPublic { get; set; }

        public Try<Record<string, string>> LastMessage { get; set; }

        public event EventHandler<KafkaEventArgs> SubscribeConsumePublic;

        public Task PollingSub { get; set; }

        public void RaiseEvent(KafkaEventArgs kEa)
        {
            if (SubscribeConsumePublic != null)
            {
                SubscribeConsumePublic.Invoke(this, kEa);
            }
        }
    }
}
