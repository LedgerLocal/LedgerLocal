using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace LedgerLocal.Dto.Chain
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class LimitOrderBodyDescription
    {
        [JsonProperty("fee")]
        public AmountDescription Fee { get; set; }

        [JsonProperty("seller")]
        public string Seller { get; set; }

        [JsonProperty("amount_to_sell")]
        public AmountDescription AmountToSell { get; set; }

        [JsonProperty("min_to_receive")]
        public AmountDescription MinToReceive { get; set; }

        [JsonProperty("expiration")]
        public string Expiration { get; set; }

        [JsonProperty("fill_or_kill")]
        public bool FillOrKill { get; set; }
    }
}
