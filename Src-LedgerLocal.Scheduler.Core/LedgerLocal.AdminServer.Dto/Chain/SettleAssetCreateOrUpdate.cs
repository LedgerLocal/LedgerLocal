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
    public partial class SettleAssetCreateOrUpdate
    {

        /*
         
account_to_settle: the name or id of the account owning the asset
amount_to_settle: the amount of the named asset to schedule for settlement
symbol: the name or id of the asset to settlement on
broadcast: true to broadcast the transaction on the network

         */

        public SettleAssetCreateOrUpdate()
        {
            
        }

        [DataMember(Name = "accountToSettle")]
        public string AccountToSettle { get; set; }

        [DataMember(Name = "amountToSettle")]
        public string AmountToSettle { get; set; }

        [DataMember(Name = "symbol")]
        public string Symbol { get; set; }

                

        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;

    }
}
