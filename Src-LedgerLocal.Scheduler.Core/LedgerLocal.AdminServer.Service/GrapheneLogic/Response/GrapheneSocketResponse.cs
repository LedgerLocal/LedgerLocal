using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.Service.GrapheneLogic.Response
{
    public class GrapheneSocketResponse<T>
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("error")]
        public GrapheneError Error { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("result")]
        public T Result { get; set; }
    }
}
