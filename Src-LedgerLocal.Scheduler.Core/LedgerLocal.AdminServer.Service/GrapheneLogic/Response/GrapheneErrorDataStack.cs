using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.Service.GrapheneLogic.Response
{
    public class GrapheneErrorDataStack
    {
        [JsonProperty("context")]
        public GrapheneErrorDataStackContext Context { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonIgnore]
        public object Data { get; set; }
    }
}
