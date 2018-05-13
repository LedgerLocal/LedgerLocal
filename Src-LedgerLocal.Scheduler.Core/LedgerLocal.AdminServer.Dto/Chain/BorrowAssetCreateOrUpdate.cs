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
    public partial class BorrowAssetCreateOrUpdate
    {

        /*
         
borrower_name: the name or id of the account associated with the transaction.
amount_to_borrow: the amount of the asset being borrowed. Make this value negative to pay back debt.
asset_symbol: the symbol or id of the asset being borrowed.
amount_of_collateral: the amount of the backing asset to add to your collateral position. Make this negative to claim back some of your collateral. The backing asset is defined in the bitasset_options for the asset being borrowed.
broadcast: true to broadcast the transaction on the network

         */

        public BorrowAssetCreateOrUpdate()
        {
            
        }

        [DataMember(Name = "borrowerName")]
        public string BorrowerName { get; set; }

        [DataMember(Name = "amountToBorrow")]
        public decimal AmountToBorrow { get; set; }

        [DataMember(Name = "assetSymbol")]
        public string AssetSymbol { get; set; }

        [DataMember(Name = "amountOfCollateral")]
        public decimal AmountOfCollateral { get; set; }
        

        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;

    }
}
