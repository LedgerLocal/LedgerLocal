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
    public partial class BitassetOptionCreateOrUpdate
    {
        [JsonProperty("feed_lifetime_sec")]
        public ulong Feed_lifetime_sec { get; set; }

        [JsonProperty("minimum_feeds")]
        public ulong Minimum_feeds { get; set; }

        [JsonProperty("force_settlement_delay_sec")]
        public ulong Force_settlement_delay_sec { get; set; }

        [JsonProperty("force_settlement_offset_percent")]
        public ulong Force_settlement_offset_percent { get; set; }

        [JsonProperty("maximum_force_settlement_volume")]
        public ulong Maximum_force_settlement_volume { get; set; }

        [JsonProperty("short_backing_asset")]
        public string Short_backing_asset { get; set; }
    }
}
