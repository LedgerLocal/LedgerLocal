using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

/*

"feed_lifetime_sec" : 60 * 60 * 24,
"minimum_feeds" : 7,
"force_settlement_delay_sec" : 60 * 60 * 24,
"force_settlement_offset_percent" : 1 * assetConstants.GRAPHENE_1_PERCENT,
"maximum_force_settlement_volume" : 20 * assetConstants.GRAPHENE_1_PERCENT,
"short_backing_asset" : "1.3.0"

*/

namespace LedgerLocal.Service.GrapheneLogic
{
    public class GrapheneBitAssetOptions
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
