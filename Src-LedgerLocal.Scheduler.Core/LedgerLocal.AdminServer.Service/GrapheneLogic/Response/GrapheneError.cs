using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.Service.GrapheneLogic.Response
{
    public class GrapheneError
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public string data { get; set; }


    }
}
