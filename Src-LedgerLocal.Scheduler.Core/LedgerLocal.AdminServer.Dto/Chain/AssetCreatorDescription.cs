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
    public partial class AssetCreatorDescription
    {

        public AssetCreatorDescription()
        { 
        }

        [JsonProperty("fee")]
        public AmountDescription Fee { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("precision")]
        public ulong Precision { get; set; }

        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        [JsonProperty("common_options")]
        public AssetOptionCreateOrUpdate Options { get; set; }

        [JsonProperty("bitasset_opts")]
        public BitassetOptionCreateOrUpdate BitAssetOptions { get; set; }

        [JsonProperty("is_prediction_market")]
        public bool Is_prediction_market { get; set; }

    }
}
