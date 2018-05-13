using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.Service.GrapheneLogic.Model
{
    public class GraphenePriceFeedExchangeRate
    {
        [JsonProperty("quote")]
        public GrapheneAmount Quote { get; set; }

        [JsonProperty("base")]
        public GrapheneAmount Base { get; set; }
    }
}
