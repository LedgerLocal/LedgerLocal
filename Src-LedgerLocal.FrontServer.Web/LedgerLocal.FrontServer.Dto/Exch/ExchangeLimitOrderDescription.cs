using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LedgerLocal.FrontServer.Dto.Exch
{
    [DataContract]
    public partial class ExchangeLimitOrderDescription
    {

        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("strguidone")]
        public string StrGuidOne { get; set; }

        [JsonProperty("strguidtwo")]
        public string StrGuidTwo { get; set; }

        [JsonProperty("fee")]
        public AmountDescription Fee { get; set; }

        [JsonProperty("pays")]
        public AmountDescription Pays { get; set; }

        [JsonProperty("receives")]
        public AmountDescription Receives { get; set; }

    }
}
