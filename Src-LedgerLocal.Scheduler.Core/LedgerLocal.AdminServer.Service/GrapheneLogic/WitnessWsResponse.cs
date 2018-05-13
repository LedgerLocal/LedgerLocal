using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.Service.GrapheneLogic
{
    public class WitnessWsResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("result")]
        public object Result { get; set; }
    }
}
