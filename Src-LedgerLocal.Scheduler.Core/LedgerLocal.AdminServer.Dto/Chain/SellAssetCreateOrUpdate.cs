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
    public partial class SellAssetCreateOrUpdate
    {

        /*
         
seller_account: the account providing the asset being sold, and which will receive the proceeds of the sale.
amount_to_sell: the amount of the asset being sold to sell (in nominal units)
symbol_to_sell: the name or id of the asset to sell
min_to_receive: the minimum amount you are willing to receive in return for selling the entire amount_to_sell
symbol_to_receive: the name or id of the asset you wish to receive
timeout_sec: if the order does not fill immediately, this is the length of time the order will remain on the order books before it is cancelled and the un-spent funds are returned to the seller’s account
fill_or_kill: if true, the order will only be included in the blockchain if it is filled immediately; if false, an open order will be left on the books to fill any amount that cannot be filled immediately.
broadcast: true to broadcast the transaction on the network

         */

        public SellAssetCreateOrUpdate()
        {
            
        }

        [DataMember(Name = "sellerAccount")]
        public string SellerAccount { get; set; }

        [DataMember(Name = "amountToSell")]
        public string AmountToSell { get; set; }

        [DataMember(Name = "symbolToSell")]
        public string SymbolToSell { get; set; }

        [DataMember(Name = "minToReceive")]
        public string MinToReceive { get; set; }

        [DataMember(Name = "symbolToReceive")]
        public string SymbolToReceive { get; set; }

        [DataMember(Name = "timeout")]
        public int Timeout { get; set; } = 0;

        [DataMember(Name = "fillOrKill")]
        public bool FillOrKill { get; set; } = false;

        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;

    }
}
