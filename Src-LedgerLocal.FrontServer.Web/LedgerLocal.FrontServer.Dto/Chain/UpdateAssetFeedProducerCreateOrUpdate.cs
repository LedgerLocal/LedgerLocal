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
    public partial class UpdateAssetFeedProducerCreateOrUpdate
    {

        /*

symbol: the name or id of the asset to update
new_feed_producers: a list of account names or ids which are authorized to produce feeds for the asset. this list will completely replace the existing list
broadcast: true to broadcast the transaction on the network

         */

        public UpdateAssetFeedProducerCreateOrUpdate()
        {
            NewFeedProducers = new List<string>();
        }

        [DataMember(Name = "symbol")]
        public string Symbol { get; set; }

        [DataMember(Name = "newFeedProducers")]
        public List<string> NewFeedProducers { get; set; }

        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;

    }
}
