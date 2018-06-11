using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LedgerLocal.FrontServer.Service
{
    public class LedgerLocalHub : Hub
    {
        private static long _userCount = 0;
        private ILogger<LedgerLocalHub> _logger;

        public LedgerLocalHub(ILogger<LedgerLocalHub> logger)
        {
            _logger = logger;
        }

        public long GetOnline()
        {
            return _userCount;
        }

        public override async Task OnConnectedAsync()
        {
            Interlocked.Increment(ref _userCount);

            await Clients.All.SendCoreAsync("online", new object[] { _userCount });

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            if (Interlocked.Read(ref _userCount) > 0)
            {
                Interlocked.Decrement(ref _userCount);
            }

            await Clients.All.SendCoreAsync("online", new object[] { _userCount });

            await base.OnDisconnectedAsync(exception);
        }
    }
}
