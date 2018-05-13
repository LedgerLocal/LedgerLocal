using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;

namespace LedgerLocal.AdminServer.Service.BusinessImplService.Contract
{
    public interface ITelegramClientFactory
    {
        ITelegramBotClient PublicClient { get; set; }

        ITelegramBotClient AdminClient { get; set; }
    }
}
