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
    public partial class TransferFromBlindCreateOrUpdate
    {

        public TransferFromBlindCreateOrUpdate()
        {
        }

        [DataMember(Name = "fromBlindAccountKeyOrLabel")]
        public string FromBlindAccountKeyOrLabel { get; set; }

        [DataMember(Name = "toAccountIdOrName")]
        public string ToAccountIdOrName { get; set; }

        [DataMember(Name = "amount")]
        public string Amount { get; set; }

        [DataMember(Name = "assetSymbol")]
        public string AssetSymbol { get; set; }

        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;

    }
}
