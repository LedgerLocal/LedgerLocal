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

    /*
     *
   signed_transaction graphene::wallet::wallet_api::vote_for_witness(string voting_account, string witness, bool approve, bool broadcast = false)
Vote for a given witness.
An account can publish a list of all witnesses they approve of. This command allows you to add or remove witnesses from this list. Each account’s vote is weighted according to the number of shares of the core asset owned by that account at the time the votes are tallied.
Note
you cannot vote against a witness, you can only vote for the witness or not vote for the witness.
Return
the signed transaction changing your vote for the given witness
Parameters
voting_account: the name or id of the account who is voting with their shares
witness: the name or id of the witness’ owner account
approve: true if you wish to vote in favor of that witness, false to remove your vote in favor of that witness
broadcast: true if you wish to broadcast the transaction
     * 
    */

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class VoteForWitnessCreateOrUpdate
    {
        public VoteForWitnessCreateOrUpdate()
        {           
        }

        [DataMember(Name= "votingAccount")]
        public string VotingAccount { get; set; }

        [DataMember(Name= "witness")]
        public string Witness { get; set; }

        [DataMember(Name = "approve")]
        public bool Approve { get; set; }

        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;
    }
}
