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
