using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.Service.GrapheneLogic.Response
{
    public class GrapheneErrorDataStackContext
    {
        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("file")]
        public string File { get; set; }

        [JsonProperty("line")]
        public string Line { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        [JsonProperty("thread_name")]
        public string ThreadName { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }
}
