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
    public partial class GlobalSettleAssetCreateOrUpdate
    {

        /*
         
symbol: the name or id of the asset to force settlement on
settle_price: the price at which to settle
broadcast: true to broadcast the transaction on the network

         */

        public GlobalSettleAssetCreateOrUpdate()
        {
            
        }

        [DataMember(Name = "symbol")]
        public string Symbol { get; set; }

        [DataMember(Name = "settlePrice")]
        public string SettlePrice { get; set; }

               

        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;

    }
}
