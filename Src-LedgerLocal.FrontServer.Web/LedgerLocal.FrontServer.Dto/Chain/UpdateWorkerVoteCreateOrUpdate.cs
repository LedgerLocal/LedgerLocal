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
    public partial class UpdateWorkerVoteCreateOrUpdate
    {

        /*
         
account: The account which will pay the fee and update votes.
worker_vote_delta: {“vote_for” : [...], “vote_against” : [...], “vote_abstain” : [...]}
broadcast: true if you wish to broadcast the transaction.

         */

        public UpdateWorkerVoteCreateOrUpdate()
        {
            
        }

        [DataMember(Name = "account")]
        public string Account { get; set; }

        [DataMember(Name = "workerVoteDelta")]
        public string WorkerVoteDelta { get; set; }
        
        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;

    }
}
