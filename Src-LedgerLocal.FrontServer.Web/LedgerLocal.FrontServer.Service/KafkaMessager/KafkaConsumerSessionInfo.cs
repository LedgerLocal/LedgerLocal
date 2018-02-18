using Confluent.Kafka;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LedgerLocal.FrontServer.Service.KafkaMessager
{
    public class KafkaConsumerSessionInfo<T>
    {
        public Consumer<string, T> Consumer { get; set; }

        public event EventHandler<KafkaEventArgs<T>> SubscribeConsumePublic;

        public IDisposable Sub1 {get;set;}

        public void RaiseEvent(KafkaEventArgs<T> kEa)
        {
            if (SubscribeConsumePublic != null)
            {
                SubscribeConsumePublic.Invoke(this, kEa);
            }
        }

        internal void DisposeSubscriber()
        {
            //if(Sub1 != null)
            //{
            //    Sub1.Dispose();
            //    SubscribeConsumePublic = null;
            //}
        }
    }
}
