using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.Service.GrapheneLogic.Model
{
    public class GraphenePriceFeed
    {
        [JsonProperty("settlement_price")]
        public GraphenePriceFeedSettlement SettlementPrice { get; set; }

        [JsonProperty("core_exchange_rate")]
        public GraphenePriceFeedExchangeRate CoreExchangeRate { get; set; }
    }
}
