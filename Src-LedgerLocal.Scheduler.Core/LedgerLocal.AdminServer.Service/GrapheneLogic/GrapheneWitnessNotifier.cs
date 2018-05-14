using LedgerLocal.AdminServer.Service;
using LedgerLocal.AdminServer.Service.Contract;
using LedgerLocal.Service.GrapheneLogic.Request;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LedgerLocal.Service.GrapheneLogic
{
    public class GrapheneWitnessNotifier
    {
        private IWebSocketClientFactory _wsClientFact;
        private IGrapheneConfig _grapheneConfig;

        public GrapheneWitnessNotifier(IWebSocketClientFactory wsClientFact,
            IGrapheneConfig grapheneConfig)
        {
            _wsClientFact = wsClientFact;
            _grapheneConfig = grapheneConfig;
        }

        public async Task<WebSocketSession> InitNotifierForMarket(string assetSource, string assetDestination)
        {
            var m_id = 1;

            var ws = await _wsClientFact.GetContiniousSession(assetSource, assetDestination, _grapheneConfig.GrapheneBlockchainWs);

            if (ws.SubscriptionObject != null)
            {
                ws.IsBusy = true;
                return ws;
            }

            //Login
            GrapheneSocketRequest r1 = new GrapheneSocketRequest("login", m_id++, 1, new object[] { "", "" });
            string requestLogin = JsonConvert.SerializeObject(r1);

            var tokenLogin = new CancellationTokenSource();
            await ws.ClientWebSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(requestLogin)), WebSocketMessageType.Text, true, tokenLogin.Token);

            var resultLogin = await ReceiveTrigger(ws.ClientWebSocket);
            var resultLoginEntity = JsonConvert.DeserializeObject<WitnessWsResponse>(resultLogin);

            //Database
            GrapheneSocketRequest r2 = new GrapheneSocketRequest("database", m_id++, 1, Enumerable.Empty<object>().ToArray());
            string requestDatabase = JsonConvert.SerializeObject(r2);

            var tokenDatabase = new CancellationTokenSource();
            await ws.ClientWebSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(requestDatabase)), WebSocketMessageType.Text, true, tokenDatabase.Token);

            var resultDatabase = await ReceiveTrigger(ws.ClientWebSocket);
            var resultDatabaseEntity = JsonConvert.DeserializeObject<WitnessWsResponse>(resultDatabase);

            var dbId = Convert.ToInt32(resultDatabaseEntity.Result);

            Random rnd = new Random();
            int nxtSession = rnd.Next(1, 1000);

            //SubscriptionMarket
            GrapheneSocketRequest r3 = new GrapheneSocketRequest("subscribe_to_market", m_id++, 2, new object[] { nxtSession, assetSource, assetDestination });
            string requestSubscription = JsonConvert.SerializeObject(r3);

            var tokenSubscription = new CancellationTokenSource();
            await ws.ClientWebSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(requestSubscription)), WebSocketMessageType.Text, true, tokenSubscription.Token);

            var resultSubscription = await ReceiveTrigger(ws.ClientWebSocket);
            var resultSubscriptionEntity = JsonConvert.DeserializeObject<WitnessWsResponse>(resultSubscription);

            ws.ObservableConsumer = ws.OnTickCollection.GetConsumingEnumerable();

            ws.ObservableTuple = ws.ObservableConsumer.ToObservable(Scheduler.Default);

            ws.SubscriptionConsume = ws.ObservableTuple
                .Buffer(TimeSpan.FromSeconds(1), 5)
                .Subscribe(x => 
                {
                        
                    foreach(var e1 in x)
                    {
                        ws.RaiseEvent(e1);
                    }
                    
                });

            //ws.SubscriptionConsume = ws.ObservableTuple.Subscribe(x =>
            //{
            //    ws.RaiseEvent(x);
            //});

            var source = Observable.Interval(TimeSpan.FromSeconds(1));
            Subject<long> subject = new Subject<long>();
            var subSource = source.Subscribe(subject);
            ws.SubscriptionObject = subject.Subscribe(
                                     l =>
                                     {
                                         var resSub = ReceiveTriggerContinious(ws.ClientWebSocket);
                                         resSub.Wait();


                                         if (!string.IsNullOrWhiteSpace(resSub.Result))
                                         {
                                             ws.OnTickCollection.Add(new Tuple<DateTime, string>(DateTime.Now, resSub.Result));
                                         }

                                         Thread.Sleep(1000);
                                     },
                                     () => Console.WriteLine("Sequence Completed."));

            ws.IsBusy = true;
            return ws;
        }

        public async Task<WebSocketSession> InitNotifierForObjects(string[] objects)
        {
            var m_id = 1;

            var ws = await _wsClientFact.GetContiniousSessionForAction("balance", _grapheneConfig.GrapheneBlockchainWs);

            if (ws.SubscriptionObject != null)
            {
                ws.IsBusy = true;
                return ws;
            }

            //Login
            GrapheneSocketRequest r1 = new GrapheneSocketRequest("login", m_id++, 1, new object[] { "", "" });
            string requestLogin = JsonConvert.SerializeObject(r1);

            var tokenLogin = new CancellationTokenSource();
            await ws.ClientWebSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(requestLogin)), WebSocketMessageType.Text, true, tokenLogin.Token);

            var resultLogin = await ReceiveTrigger(ws.ClientWebSocket);
            var resultLoginEntity = JsonConvert.DeserializeObject<WitnessWsResponse>(resultLogin);

            //Database
            GrapheneSocketRequest r2 = new GrapheneSocketRequest("database", m_id++, 1, Enumerable.Empty<object>().ToArray());
            string requestDatabase = JsonConvert.SerializeObject(r2);

            var tokenDatabase = new CancellationTokenSource();
            await ws.ClientWebSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(requestDatabase)), WebSocketMessageType.Text, true, tokenDatabase.Token);

            var resultDatabase = await ReceiveTrigger(ws.ClientWebSocket);
            var resultDatabaseEntity = JsonConvert.DeserializeObject<WitnessWsResponse>(resultDatabase);

            var dbId = Convert.ToInt32(resultDatabaseEntity.Result);

            //History
            GrapheneSocketRequest r3 = new GrapheneSocketRequest("history", m_id++, 1, new object[] { "", "" });
            string requestHistory = JsonConvert.SerializeObject(r3);

            var tokenHistory = new CancellationTokenSource();
            await ws.ClientWebSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(requestHistory)), WebSocketMessageType.Text, true, tokenHistory.Token);

            var resultHistory = await ReceiveTrigger(ws.ClientWebSocket);
            var resultHistoryEntity = JsonConvert.DeserializeObject<WitnessWsResponse>(resultHistory);

            //set_subscribe_callback
            GrapheneSocketRequest r4 = new GrapheneSocketRequest("set_subscribe_callback", m_id++, 2, new object[] { 5, false });
            string requestSubscribe = JsonConvert.SerializeObject(r4);

            var tokenSubscribe = new CancellationTokenSource();
            await ws.ClientWebSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(requestSubscribe)), WebSocketMessageType.Text, true, tokenSubscribe.Token);

            var resultSubscribe = await ReceiveTrigger(ws.ClientWebSocket);
            var resultSubscribeEntity = JsonConvert.DeserializeObject<WitnessWsResponse>(resultSubscribe);

            //get_objects
            GrapheneSocketRequest r5 = new GrapheneSocketRequest("get_objects", m_id++, 2, new object[] { objects });
            string requestGetObject = JsonConvert.SerializeObject(r5);

            var tokenGetObject = new CancellationTokenSource();
            await ws.ClientWebSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(requestGetObject)), WebSocketMessageType.Text, true, tokenGetObject.Token);

            var resultGetObject = await ReceiveTrigger(ws.ClientWebSocket);
            var resultGetObjectEntity = JsonConvert.DeserializeObject<WitnessWsResponse>(resultGetObject);

            ws.ObservableConsumer = ws.OnTickCollection.GetConsumingEnumerable();

            ws.ObservableTuple = ws.ObservableConsumer.ToObservable(Scheduler.Default);

            ws.SubscriptionConsume = ws.ObservableTuple
                .Buffer(TimeSpan.FromSeconds(1), 5)
                .Subscribe(x =>
                {

                    foreach (var e1 in x)
                    {
                        ws.RaiseEvent(e1);
                    }

                });

            var source = Observable.Interval(TimeSpan.FromSeconds(1));
            Subject<long> subject = new Subject<long>();
            var subSource = source.Subscribe(subject);
            ws.SubscriptionObject = subject.Subscribe(
                                     l =>
                                     {
                                         var resSub = ReceiveTriggerContinious(ws.ClientWebSocket);
                                         resSub.Wait();


                                         if (!string.IsNullOrWhiteSpace(resSub.Result))
                                         {
                                             ws.OnTickCollection.Add(new Tuple<DateTime, string>(DateTime.Now, resSub.Result));
                                         }

                                         Thread.Sleep(1000);
                                     },
                                     () => Console.WriteLine("Sequence Completed."));

            ws.IsBusy = true;
            return ws;
        }

        private async Task<string> ReceiveTriggerContinious(ClientWebSocket wsClient)
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
                        lstB.Add(buffer);
                    }
                }

                if (lstB.Count > 0)
                {
                    var msgString = Encoding.UTF8.GetString(ConvertToByteArray(lstB).ToArray());
                    msgString = msgString.Replace("\0", string.Empty);
                    if (IsValidJson(msgString))
                    {
                        return msgString;
                    }
                }
            }

            return string.Empty;
        }

        private async Task<string> ReceiveTrigger(ClientWebSocket wsClient)
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
                        return msgString;
                    }
                }
            }

            return string.Empty;
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
    }
}
