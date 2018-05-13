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
    public partial class AssetOptionCreateOrUpdate
    {

        public AssetOptionCreateOrUpdate()
        {
            Whitelist_authorities = new List<string>();
            Blacklist_authorities = new List<string>();
            Whitelist_markets = new List<string>();
            Blacklist_markets = new List<string>();
        }

        [JsonProperty("max_supply")]
        public ulong Max_supply { get; set; }

        [JsonProperty("market_fee_percent")]
        public decimal Market_fee_percent { get; set; }

        [JsonProperty("max_market_fee")]
        public ulong Max_market_fee { get; set; }

        [JsonProperty("issuer_permissions")]
        public uint Issuer_permissions { get; set; }

        [JsonProperty("flags")]
        public uint Flags { get; set; }

        [JsonProperty("core_exchange_rate")]
        public ExchangeRateCreateOrUpdate Core_exchange_rate { get; set; }

        [JsonProperty("whitelist_authorities")]
        public List<string> Whitelist_authorities { get; set; }

        [JsonProperty("blacklist_authorities")]
        public List<string> Blacklist_authorities { get; set; }

        [JsonProperty("whitelist_markets")]
        public List<string> Whitelist_markets { get; set; }

        [JsonProperty("blacklist_markets")]
        public List<string> Blacklist_markets { get; set; }

        [JsonProperty("description")]
        public string Description
        {
            get; set;
        }
    }
}
