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
    public partial class ReverseAssetCreateOrUpdate
    {

        /*
         
from: the account containing the asset you wish to burn
amount: the amount to burn, in nominal units
symbol: the name or id of the asset to burn
broadcast: true to broadcast the transaction on the network

         */

        public ReverseAssetCreateOrUpdate()
        {
            
        }

        [DataMember(Name = "from")]
        public string From { get; set; }

        [DataMember(Name = "amount")]
        public string Amount { get; set; }

        [DataMember(Name = "symbol")]
        public string Symbol { get; set; }
        
        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;

    }
}
