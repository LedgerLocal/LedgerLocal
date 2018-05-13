using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.Service.GrapheneLogic.Model
{
    public class GrapheneAccountSimple
    {
        [JsonProperty("accountName")]
        public string AccountName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
