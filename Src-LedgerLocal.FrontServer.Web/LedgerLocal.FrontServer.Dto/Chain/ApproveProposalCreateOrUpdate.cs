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
    public partial class ApproveProposalCreateOrUpdate
    {
        public ApproveProposalCreateOrUpdate()
        {           
        }

        [DataMember(Name="payingAccountId")]
        public string PayingAccountId { get; set; }

        [DataMember(Name="proposalId")]
        public string ProposalId { get; set; }

        [DataMember(Name = "delta")]
        public string Delta { get; set; }

        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;
    }
}
