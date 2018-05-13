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
    public partial class VoteForComitteeMemberCreateOrUpdate
    {
        public VoteForComitteeMemberCreateOrUpdate()
        {           
        }

        [DataMember(Name= "votingAccount")]
        public string VotingAccount { get; set; }

        [DataMember(Name= "committeeMember")]
        public string CommitteeMember { get; set; }

        [DataMember(Name = "approve")]
        public bool Approve { get; set; }

        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;
    }
}
