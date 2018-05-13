using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LedgerLocal.AdminServer.Dto.Exch
{
    [DataContract]
    public partial class AmountDescription
    {

        public AmountDescription()
        {

        }

        [JsonProperty("amount")]
        public ulong Amount { get; set; }

        [JsonProperty("asset_id")]
        public string Asset_id { get; set; }
    }
}
