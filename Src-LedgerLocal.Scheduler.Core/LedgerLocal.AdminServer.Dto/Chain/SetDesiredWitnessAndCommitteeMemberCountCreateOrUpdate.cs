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
signed_transaction graphene::wallet::wallet_api::set_desired_witness_and_committee_member_count(string account_to_modify, uint16_t desired_number_of_witnesses, uint16_t desired_number_of_committee_members, bool broadcast = false)
Set your vote for the number of witnesses and committee_members in the system.
Each account can voice their opinion on how many committee_members and how many witnesses there should be in the active committee_member/active witness list. These are independent of each other. You must vote your approval of at least as many committee_members or witnesses as you claim there should be (you can’t say that there should be 20 committee_members but only vote for 10).
There are maximum values for each set in the blockchain parameters (currently defaulting to 1001).
This setting can be changed at any time. If your account has a voting proxy set, your preferences will be ignored.
Return
the signed transaction changing your vote proxy settings
Parameters
account_to_modify: the name or id of the account to update
number_of_committee_members: the number
broadcast: true if you wish to broadcast the transaction
     * 
    */

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class SetDesiredWitnessAndCommitteeMemberCountCreateOrUpdate
    {
        public SetDesiredWitnessAndCommitteeMemberCountCreateOrUpdate()
        {           
        }

        [DataMember(Name= "accountToModify")]
        public string AccountToModify { get; set; }

        [DataMember(Name= "desiredNumberOfWitnesses")]
        public int DesiredNumberOfWitnesses { get; set; }

        [DataMember(Name = "desiredNumberOfCommitteeMembers")]
        public int DesiredNumberOfCommitteeMembers { get; set; }

        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;
    }
}
