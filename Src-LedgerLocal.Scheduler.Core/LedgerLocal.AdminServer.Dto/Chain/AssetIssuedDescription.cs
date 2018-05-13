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
    public partial class AssetIssuedDescription
    {

        public AssetIssuedDescription()
        { 
        }

        [JsonProperty("fee")]
        public AmountDescription Fee { get; set; }

        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        [JsonProperty("asset_to_issue")]
        public AmountDescription AssetToIssue { get; set; }

        [JsonProperty("issue_to_account")]
        public string IssueToAccount { get; set; }

        [JsonProperty("memo")]
        public MemoDescription Memo { get; set; }

    }
}
