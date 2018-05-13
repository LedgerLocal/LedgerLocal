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
    public partial class ProposeBuilderTransactionCreateOrUpdate
    {
        public ProposeBuilderTransactionCreateOrUpdate()
        {
        }

        [DataMember(Name = "transactionHandle")]
        public TransactionHandleDescription TransactionHandle { get; set; }

        [DataMember(Name = "accountNameOrId")]
        public string AccountNameOrId { get; set; }

        [DataMember(Name = "expiration")]
        public DateTime Expiration { get; set; }

        [DataMember(Name = "reviewPeriodSeconds")]
        public int ReviewPeriodSeconds { get; set; }

        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = true;
    }
}
