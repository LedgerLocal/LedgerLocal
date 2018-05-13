using LedgerLocal.AdminServer.Service.BusinessImplService.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;

namespace LedgerLocal.AdminServer.Service.BusinessImplService
{
    public class TelegramClientFactory : ITelegramClientFactory
    {
        public ITelegramBotClient PublicClient { get; set; }

        public ITelegramBotClient AdminClient { get; set; }
    }
}
