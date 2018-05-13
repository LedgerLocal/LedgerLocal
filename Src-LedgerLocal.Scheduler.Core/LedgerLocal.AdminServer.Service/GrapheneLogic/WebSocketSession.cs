using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace LedgerLocal.Service.GrapheneLogic
{
    public class WebSocketSession
    {
        public WebSocketSession()
        {
            OnTickCollection = new BlockingCollection<Tuple<DateTime, string>>();
            IsBusy = false;
        }

        public bool IsBusy { get; set; }

        public ClientWebSocket ClientWebSocket { get; set; }

        public string Url { get; set; }

        public string ThreadId { get; set; }

        public GrapheneWebsocket ObjectWebSocket { get; set; }

        public BlockingCollection<Tuple<DateTime, string>> OnTickCollection { get; set; }

        public IDisposable SubscriptionObject { get; set; }

        public IObservable<Tuple<DateTime, string>> ObservableTuple { get; set; }

        public IEnumerable<Tuple<DateTime, string>> ObservableConsumer { get; set; }

        public event EventHandler<Tuple<DateTime, string>> SubscribeConsumePublic;

        public void RaiseEvent(Tuple<DateTime, string> kEa)
        {
            if (SubscribeConsumePublic != null)
            {
                SubscribeConsumePublic.Invoke(this, kEa);
            }
        }

        public IDisposable SubscriptionConsume { get; set; }
    }
}
