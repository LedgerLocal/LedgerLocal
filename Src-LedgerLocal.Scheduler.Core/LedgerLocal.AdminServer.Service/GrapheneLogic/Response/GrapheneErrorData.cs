using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.Service.GrapheneLogic.Response
{
    public class GrapheneErrorData
    {
        public GrapheneErrorData()
        {
            Stack = new List<GrapheneErrorDataStack>();
        }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
        
        [JsonProperty("stack")]
        public List<GrapheneErrorDataStack> Stack { get; set; }
    }
}
