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
    public partial class PreviewBuilderTransactionCreateOrUpdate
    {
        public PreviewBuilderTransactionCreateOrUpdate()
        {
        }

        [DataMember(Name = "transactionHandle")]
        public TransactionHandleDescription TransactionHandle { get; set; }
    }
}
