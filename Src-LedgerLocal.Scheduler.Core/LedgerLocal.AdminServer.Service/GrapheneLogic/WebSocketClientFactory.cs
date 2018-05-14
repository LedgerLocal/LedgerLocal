using LedgerLocal.AdminServer.Service.Contract;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LedgerLocal.Service.GrapheneLogic
{
    public class WebSocketClientFactory : IWebSocketClientFactory
    {
        private ConcurrentDictionary<string, WebSocketSession> _wsDico;
        private object _sync = new object();

        public WebSocketClientFactory()
        {
            _wsDico = new ConcurrentDictionary<string, WebSocketSession>();
        }

        public async Task<WebSocketSession> GetContiniousSessionForAction(string action, string url)
        {
            var count = 0;
            var idString = string.Concat("continious-", action, "_", count);

            while (_wsDico.ContainsKey(idString) && _wsDico[idString].IsBusy)
            {
                count = count + 1;
                idString = string.Concat("continious-", action, "_", count);
            }

            if (!_wsDico.ContainsKey(idString))
            {
                return await AddSession(url, idString);
            }

            return _wsDico[idString];
        }

        public async Task<WebSocketSession> GetContiniousSession(string assetSource, string assetDestination, string url)
        {
            var count = 0;
            var idString = string.Concat("continious-", assetSource, "-", assetDestination, "_", count);

            while(_wsDico.ContainsKey(idString) && _wsDico[idString].IsBusy)
            {
                count = count + 1;
                idString = string.Concat("continious-", assetSource, "-", assetDestination, "_", count);
            }

            if (!_wsDico.ContainsKey(idString))
            {
                return await AddSession(url, idString);
            }

            return _wsDico[idString];
        }

        public async Task<WebSocketSession> GetSession(string url, string idString)
        {
            if (!_wsDico.ContainsKey(idString))
            {
                return await AddSession(url, idString);
            }

            var conn1 = _wsDico[idString];

            if (conn1.ClientWebSocket.State != WebSocketState.Open)
            {
                var token = new CancellationTokenSource();
                await conn1.ClientWebSocket.ConnectAsync(new Uri(url), token.Token);
            }

            return conn1;
        }

        public async Task<WebSocketSession> AddSession(string url, string idString)
        {
            var m_socket = new ClientWebSocket();
            m_socket.Options.SetRequestHeader(headerName: "content-type", headerValue: "application/json");

            var token = new CancellationTokenSource();
            await m_socket.ConnectAsync(new Uri(url), token.Token);

            var session = new WebSocketSession
            {
                ClientWebSocket = m_socket,
                ThreadId = Thread.CurrentThread.ManagedThreadId.ToString(),
                Url = url
            };

            if (_wsDico.TryAdd(idString, session))
            {
                return session;
            }

            return null;
        }
    }
}
