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
    public partial class CancelAssetCreateOrUpdate
    {

        /*
         
order_id: the id of order to be cancelled
broadcast: true to broadcast the transaction on the network

         */

        public CancelAssetCreateOrUpdate()
        {
            
        }

        [DataMember(Name = "orderId")]
        public string OrderId { get; set; }
        
        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;

    }
}
