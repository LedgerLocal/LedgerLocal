using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace LedgerLocal.AdminServer.Service.BusinessImplService.Contract
{
    public interface IBotService
    {
        bool Running { get; set; }

        bool IsStarted { get; }

        void Start();

        void Stop();

        long CurrentChannelId();

        Task SendMessage(string msg);

        void ProcessMessage(string msg1, long channelId, bool isPublic = false);
    }
}
