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
    public partial class CreateAssetCreateOrUpdate
    {

        /*
         
issuer: the name or id of the account who will pay the fee and become the issuer of the new asset. This can be updated later
symbol: the ticker symbol of the new asset
precision: the number of digits of precision to the right of the decimal point, must be less than or equal to 12
common: asset options required for all new assets. Note that core_exchange_rate technically needs to store the asset ID of this new asset. Since this ID is not known at the time this operation is created, create this price as though the new asset has instance ID 1, and the chain will overwrite it with the new asset’s ID.
bitasset_opts: options specific to BitAssets. This may be null unless the market_issued flag is set in common.flags
broadcast: true to broadcast the transaction on the network

         */

        public CreateAssetCreateOrUpdate()
        {
            
        }

        [DataMember(Name = "issuer")]
        public string Issuer { get; set; }

        [DataMember(Name = "symbol")]
        public string Symbol { get; set; }

        [DataMember(Name = "precision")]
        public uint Precision { get; set; }

        [DataMember(Name = "assetOptions")]
        public AssetOptionCreateOrUpdate AssetOption { get; set; }

        [DataMember(Name = "bitassetOptions")]
        public BitassetOptionCreateOrUpdate BitassetOption { get; set; }

        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;

    }
}
