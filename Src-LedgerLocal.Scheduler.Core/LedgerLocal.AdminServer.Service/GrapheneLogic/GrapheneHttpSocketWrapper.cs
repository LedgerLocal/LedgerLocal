using LedgerLocal.AdminServer.Service.Contract;
using LedgerLocal.Service.GrapheneLogic.Model;
using LedgerLocal.Service.GrapheneLogic.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LedgerLocal.Service.GrapheneLogic
{
    public class GrapheneHttpSocketWrapper
    {
        const int kTimeoutSeconds = 120;

        GrapheneWebsocket m_socket;

        Dictionary<GrapheneApi, int> m_apiMap;

        IWebSocketClientFactory _webSocketClientFactory;

        /// <summary>	Constructor. </summary>
        ///
        /// <remarks>	Paul, 19/10/2015. </remarks>
        ///
        /// <param name="url">	   	URL of the document. </param>
        /// <param name="username">	(Optional) the username. </param>
        /// <param name="password">	(Optional) the password. </param>
        public GrapheneHttpSocketWrapper(IWebSocketClientFactory wsClientFactory)
        {
            _webSocketClientFactory = wsClientFactory;

            m_apiMap = new Dictionary<GrapheneApi, int>
            {
                {GrapheneApi.@public, 0},
                {GrapheneApi.login, 1}
            };

            //if (login)
            //{
            //    bool done = false;

            //    done = true;

            //    //while (!done)
            //    //{
            //    //    try
            //    //    {
            //    //        bool success = ApiCallSync<bool>(GrapheneMethodEnum.login, GrapheneApi.login, username, password);

            //    //        int history = ApiCallSync<int>(GrapheneMethodEnum.history, GrapheneApi.login);
            //    //        int broadcast = ApiCallSync<int>(GrapheneMethodEnum.network_broadcast, GrapheneApi.login);

            //    //        m_apiMap[GrapheneApi.history] = history;
            //    //        m_apiMap[GrapheneApi.network_broadcast] = broadcast;

            //    //        done = true;
            //    //    }
            //    //    catch { }
            //    //}
            //}
        }

        public async Task Connect(string url)
        {
            var sess = await _webSocketClientFactory.GetSession(url, "simplerequestws");

            if (sess.ObjectWebSocket == null)
            {
                m_socket = new GrapheneWebsocket(sess, url);
                sess.ObjectWebSocket = m_socket;

                EventHandler<Exception> onError = null;
                onError = (object sender, Exception message) =>
                {
                    throw new GrapheneCallException("Error on WebSocket: ", message);
                };

                m_socket.OnError += onError;
            }
            else
            {
                m_socket = sess.ObjectWebSocket;
            }
            
            //m_socket.OnClose += (o, s) => Reconnect();
            //m_socket.OnError += (o, e) => Reconnect();
        }

        /// <summary>	Reconnects this object. </summary>
        ///
        /// <remarks>	Paul, 10/11/2015. </remarks>
        void Reconnect()
        {
            //m_socket.Connect();
        }

        /// <summary>	API call synchronise. </summary>
        ///
        /// <remarks>	Paul, 23/10/2015. </remarks>
        ///
        /// <typeparam name="T">	Generic type parameter. </typeparam>
        /// <param name="method">	The method. </param>
        /// <param name="args">  	A variable-length parameters list containing arguments. </param>
        ///
        /// <returns>	A T. </returns>
        public T ApiCallSync<T>(GrapheneMethodEnum method, GrapheneApi api, params object[] args)
        {
            Task<T> t = Task.Run<T>(() =>
            {
                return ApiCall<T>(method, api, args);
            });

            bool sucesss = t.Wait(kTimeoutSeconds * 1000);

            if (!sucesss)
            {
                throw new TimeoutException();
            }

            return t.Result;
        }

        /// <summary>	API call. </summary>
        ///
        /// <remarks>	Paul, 19/10/2015. </remarks>
        ///
        /// <typeparam name="T">	Generic type parameter. </typeparam>
        /// <param name="method">	The method. </param>
        /// <param name="args">  	A variable-length parameters list containing arguments. </param>
        ///
        /// <returns>	A Task&lt;T&gt; </returns>
        async public Task<T> ApiCall<T> (GrapheneMethodEnum method, GrapheneApi api, params object[] args)
        {
            TaskCompletionSource<T> task = new TaskCompletionSource<T>();
            EventHandler<string> onMessage = null;
            int id = -1;

            onMessage = (object sender, string message) =>
            {
                var conv1 = new DictionaryTwoArrayConverter<GrapheneOperation>(new List<JsonConverter>());
                var conv2 = new DictionaryTwoArrayConverter<GrapheneTransactionRecord<GrapheneOperation>>(new List<JsonConverter>() { conv1 });

                var conv3 = new DictionaryTwoArrayConverter<GrapheneAssetCreator>(new List<JsonConverter>());
                var conv4 = new DictionaryTwoArrayConverter<GrapheneTransactionRecord<GrapheneAssetCreator>>(new List<JsonConverter>() { conv3 });

                var conv5 = new DictionaryTwoArrayConverter<GrapheneAssetIssued>(new List<JsonConverter>());
                var conv6 = new DictionaryTwoArrayConverter<GrapheneTransactionRecord<GrapheneAssetIssued>>(new List<JsonConverter>() { conv5 });

                var conv7 = new DictionaryTwoArrayConverter<GrapheneLimitOrderBody>(new List<JsonConverter>());
                var conv8 = new DictionaryTwoArrayConverter<GrapheneTransactionRecord<GrapheneLimitOrderBody>>(new List<JsonConverter>() { conv7 });

                try
                {
                    GrapheneSocketResponse<T> decoded = JsonConvert.DeserializeObject<GrapheneSocketResponse<T>>(message,
                    conv1, conv2, conv3, conv4, conv5, conv6, conv7, conv8
                    );

                    if (decoded.Id == id.ToString())
                    {
                        m_socket.OnMessage -= onMessage;

                        if (decoded.Error != null)
                        {
                            task.SetException(new GrapheneRpcException(decoded.Error.Message));
                        }
                        else
                        {
                            task.SetResult(decoded.Result);
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception(string.Concat("Message Received, with error: ", message), ex);
                }

                
            };

            if (m_socket != null)
            {
                m_socket.OnMessage = null;
                m_socket.OnMessage += onMessage;
                id = m_socket.Send(method, m_apiMap[api], args);
            }

            return await task.Task;
        }
    }
}
