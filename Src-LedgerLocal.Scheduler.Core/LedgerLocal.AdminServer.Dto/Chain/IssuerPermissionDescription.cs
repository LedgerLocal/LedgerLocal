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
    public partial class IssuerPermissionDescription
    {

        public IssuerPermissionDescription()
        {
        }

        [JsonProperty("charge_market_fee")]
        public bool ChargeMarketFee { get; set; }

        [JsonProperty("white_list")]
        public bool WhiteList { get; set; }

        [JsonProperty("override_authority")]
        public bool OverrideAuthority { get; set; }

        [JsonProperty("transfer_restricted")]
        public bool TransferRestricted { get; set; }

        [JsonProperty("disable_force_settle")]
        public bool DisableForceSettle { get; set; }

        [JsonProperty("global_settle")]
        public bool GlobalSettle { get; set; }

        [JsonProperty("disable_confidential")]
        public bool DisableConfidential { get; set; }

        [JsonProperty("witness_fed_asset")]
        public bool WitnessFedAsset { get; set; }

        [JsonProperty("committee_fed_asset")]
        public bool CommitteeFedAsset { get; set; }

    }
}
