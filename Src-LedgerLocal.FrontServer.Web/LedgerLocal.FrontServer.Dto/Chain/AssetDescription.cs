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
    public partial class AssetDescription
    {

        public AssetDescription()
        {
            
        }

        [DataMember(Name="assetId")]
        public string AssetId { get; set; }

        [DataMember(Name = "assetName")]
        public string AssetName { get; set; }

        [DataMember(Name="assetSymbol")]
        public string AssetSymbol { get; set; }

        [JsonProperty("precision")]
        public ulong Precision { get; set; }

        [DataMember(Name = "dynamicAssetDataId")]
        public string DynamicAssetDataId { get; set; }

        [DataMember(Name = "issuer")]
        public string Issuer { get; set; }
        
    }
}
