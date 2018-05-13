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
    public partial class TransactionDescription
    {

        public TransactionDescription()
        {
            Signatures = new List<SignatureDescription>();
            Operations = new List<OperationDescription>();
        }
        
        [DataMember(Name="blockNum")]
        public long BlockNum { get; set; }

        [DataMember(Name="blockPrefix")]
        public long BlockPrefix { get; set; }

        [DataMember(Name = "expiration")]
        public DateTime Expiration { get; set; }

        [DataMember(Name = "operations")]
        public List<OperationDescription> Operations { get; set; }

        [DataMember(Name = "signatures")]
        public List<SignatureDescription> Signatures { get; set; }

    }
}
