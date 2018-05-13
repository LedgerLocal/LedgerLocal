using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.Dto.Chain
{
    public class AmountDescriptionSimple
    {

        [JsonProperty("amount")]
        public ulong Amount { get; set; }

        [JsonProperty("asset_id")]
        public string Asset_id { get; set; }

    }
}
