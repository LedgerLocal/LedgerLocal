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
    public partial class PublishAssetFeedCreateOrUpdate
    {

        /*
         
publishing_account: the account publishing the price feed
symbol: the name or id of the asset whose feed we’re publishing
feed: the price_feed object containing the three prices making up the feed
broadcast: true to broadcast the transaction on the network

         */

        public PublishAssetFeedCreateOrUpdate()
        {
            
        }

        [DataMember(Name = "publishingAccount")]
        public string PublishingAccount { get; set; }

        [DataMember(Name = "symbol")]
        public string Symbol { get; set; }

        [DataMember(Name = "feed")]
        public PriceFeedCreateOrUpdate Feed { get; set; }

        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;

    }
}
