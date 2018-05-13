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
    public partial class AccountProfile
    {
        public AccountProfile()
        { }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("membership_expiration_date")]
        public DateTime MembershipExpirationDate { get; set; }

        [JsonProperty("registrar")]
        public string Registrar { get; set; }

        [JsonProperty("referrer")]
        public string Referrer { get; set; }

        [JsonProperty("lifetime_referrer")]
        public string LifetimeReferrer { get; set; }

        [JsonProperty("network_fee_percentage")]
        public int NetworkFeePercentage { get; set; }

        [JsonProperty("lifetime_referrer_fee_percentage")]
        public int LifetimeReferrerFeePercentage { get; set; }

        [JsonProperty("referrer_rewards_percentage")]
        public int ReferrerRewardsPercentage { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("statistics")]
        public string Statistics { get; set; }

    }
}
