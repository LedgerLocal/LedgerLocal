using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LedgerLocal.FrontServer.Dto.Exch
{
    [DataContract]
    public partial class TransferCreateOrUpdate
    {

        public TransferCreateOrUpdate()
        {

        }

        [DataMember(Name = "from")]
        public string From { get; set; }

        [DataMember(Name = "to")]
        public string To { get; set; }

        [DataMember(Name = "amount")]
        public decimal Amount { get; set; }

        [DataMember(Name = "assetSymbol")]
        public string AssetSymbol { get; set; }

        [DataMember(Name = "memo")]
        public string Memo { get; set; }

        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;

    }
}
