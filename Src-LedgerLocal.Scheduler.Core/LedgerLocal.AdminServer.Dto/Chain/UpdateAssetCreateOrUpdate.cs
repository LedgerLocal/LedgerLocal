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
    public partial class UpdateAssetCreateOrUpdate
    {

        /*

symbol: the name or id of the asset to update
new_issuer: if changing the asset’s issuer, the name or id of the new issuer. null if you wish to remain the issuer of the asset
new_options: the new asset_options object, which will entirely replace the existing options.
broadcast: true to broadcast the transaction on the network

         */

        public UpdateAssetCreateOrUpdate()
        {
                        
        }

        [DataMember(Name = "symbol")]
        public string Symbol { get; set; }

        [DataMember(Name = "newIssuer")]
        public string NewIssuer { get; set; }

        [DataMember(Name = "newOptions")]
        public AssetOptionCreateOrUpdate NewOptions { get; set; }

        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;

    }
}
