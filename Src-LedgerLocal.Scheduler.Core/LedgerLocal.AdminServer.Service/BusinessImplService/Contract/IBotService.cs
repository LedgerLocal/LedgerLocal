using System;
using System.Collections.Generic;
using System.Text;
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

        void SendMessage(string msg);

        void ProcessMessage(string msg1, long channelId, bool isPublic = false);
    }
}
