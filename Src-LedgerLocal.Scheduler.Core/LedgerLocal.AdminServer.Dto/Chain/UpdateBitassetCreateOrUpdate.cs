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
    public partial class UpdateBitassetCreateOrUpdate
    {

        /*

symbol: the name or id of the asset to update, which must be a market-issued asset
new_options: the new bitasset_options object, which will entirely replace the existing options.
broadcast: true to broadcast the transaction on the network

         */

        public UpdateBitassetCreateOrUpdate()
        {
                        
        }

        [DataMember(Name = "symbol")]
        public string Symbol { get; set; }

        [DataMember(Name = "newOptions")]
        public BitassetOptionCreateOrUpdate NewOptions { get; set; }

        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;

    }
}
