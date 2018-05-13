using LedgerLocal.Service.GrapheneLogic.Request;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LedgerLocal.Service.GrapheneLogic
{
    public class GrapheneWebsocket
    {
        int m_id;

        public EventHandler<string> OnMessage;
        public EventHandler<string> OnClose;
        public EventHandler<Exception> OnError;

        private string _url;

        private bool _started = false;

        private BlockingCollection<string> _sendQueue;
        private IObservable<string> _sendObs;
        private IDisposable _sendSubscription;

        private BlockingCollection<string> _receiveQueue;
        private IObservable<string> _receiveObs;
        private IDisposable _receiveSubscription;

        private object _sync = new object();

        private WebSocketSession _wsSession;

        public GrapheneWebsocket(WebSocketSession wsSession, string url)
        {
            m_id = 1;
            _wsSession = wsSession;

            _sendQueue = new BlockingCollection<string>();
            _sendObs = _sendQueue
                .GetConsumingEnumerable()
                .ToObservable(Scheduler.Default);
            _sendSubscription = _sendObs.Buffer(TimeSpan.FromSeconds(1), 5)
                .Subscribe(async (a) =>
                {
                    foreach(var cmd in a)
                    {
                        var token = new CancellationTokenSource();
                        await _wsSession.ClientWebSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(cmd)), WebSocketMessageType.Text, true, token.Token);
                        _receiveQueue.Add(cmd);
                    }
                });

            _receiveQueue = new BlockingCollection<string>();
            _receiveObs = _receiveQueue
                .GetConsumingEnumerable()
                .ToObservable(Scheduler.Default);
            _receiveSubscription = _receiveObs.Buffer(TimeSpan.FromSeconds(1), 5)
                .Subscribe(async (a) =>
                {
                    try
                    {
                        if (a != null && a.Count > 0)
                        {
                            await ReceiveTrigger(_wsSession.ClientWebSocket);
                        }
                    }
                    catch (Exception e)
                    {
                        OnError(this, e);
                    }
                });
        }

        private async Task ReceiveTrigger(ClientWebSocket wsClient)
        {
            if (wsClient != null && wsClient.State == WebSocketState.Open)
            {
                var buffer = new ArraySegment<Byte>(new Byte[4096]);
                var lstB = new List<ArraySegment<Byte>>();

                var endDetected = false;

                while (!endDetected)
                {
                    var token = new CancellationTokenSource();
                    var received = await wsClient.ReceiveAsync(buffer, token.Token);
                    endDetected = received.EndOfMessage;

                    if (received.Count > 0)
                    {
                        switch (received.MessageType)
                        {
                            case WebSocketMessageType.Text:
                                lstB.Add(buffer);
                                break;
                        }
                    }
                }

                if (lstB.Count > 0)
                {
                    var msgString = Encoding.UTF8.GetString(ConvertToByteArray(lstB).ToArray());
                    msgString = msgString.Replace("\0", string.Empty);
                    if (IsValidJson(msgString))
                    {
                        if (OnMessage != null)
                        {
                            OnMessage(this, msgString);
                        }
                    }
                }
            }
        }

        public byte[] ConvertToByteArray(IList<ArraySegment<byte>> list)
        {
            var bytes = new byte[list.Sum(asb => asb.Count)];
            int pos = 0;

            foreach (var asb in list)
            {
                Buffer.BlockCopy(asb.Array, asb.Offset, bytes, pos, asb.Count);
                pos += asb.Count;
            }

            return bytes;
        }

        private static bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public int Send(GrapheneMethodEnum method, int api, params object[] args)
        {
            GrapheneSocketRequest r = new GrapheneSocketRequest(method, m_id++, api, args);
            string request = JsonConvert.SerializeObject(r);

            _sendQueue.Add(request);

            return m_id - 1;
        }
    }
}
