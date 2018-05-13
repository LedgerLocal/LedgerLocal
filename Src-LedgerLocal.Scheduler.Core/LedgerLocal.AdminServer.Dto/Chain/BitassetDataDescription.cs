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
    public partial class BitassetDataDescription
    {

        public BitassetDataDescription()
        {
            
        }

        [JsonProperty("settlement_price")]
        public PriceFeedSettlementCreateOrUpdate SettlementPrice { get; set; }

        [JsonProperty("settlement_fund")]
        public int SettlementFund { get; set; }

        [JsonProperty("options")]
        public BitassetOptionCreateOrUpdate Options { get; set; }

        [JsonProperty("force_settled_volume")]
        public int ForceDettledVolume { get; set; }

        [JsonProperty("is_prediction_market")]
        public bool IsPredictionMarket { get; set; }

        [JsonProperty("current_feed_publication_time")]
        public DateTime current_feed_publication_time { get; set; }

        [JsonProperty("current_feed")]
        public PriceFeedCreateOrUpdate CurrentFeed { get; set; }

    }
}
