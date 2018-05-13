using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.Service.GrapheneLogic.Model
{
    public class GrapheneLimitOrderBody
    {
        [JsonProperty("fee")]
        public GrapheneAmount Fee { get; set; }

        [JsonProperty("seller")]
        public string Seller { get; set; }

        [JsonProperty("amount_to_sell")]
        public GrapheneAmount AmountToSell { get; set; }

        [JsonProperty("min_to_receive")]
        public GrapheneAmount MinToReceive { get; set; }

        [JsonProperty("expiration")]
        public string Expiration { get; set; }

        [JsonProperty("fill_or_kill")]
        public bool FillOrKill { get; set; }
    }
}
