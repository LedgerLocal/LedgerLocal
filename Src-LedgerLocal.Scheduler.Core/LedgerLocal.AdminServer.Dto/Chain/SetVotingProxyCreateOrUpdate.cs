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
signed_transaction graphene::wallet::wallet_api::set_voting_proxy(string account_to_modify, optional<string> voting_account, bool broadcast = false)
Set the voting proxy for an account.
If a user does not wish to take an active part in voting, they can choose to allow another account to vote their stake.
Setting a vote proxy does not remove your previous votes from the blockchain, they remain there but are ignored. If you later null out your vote proxy, your previous votes will take effect again.
This setting can be changed at any time.
Return
the signed transaction changing your vote proxy settings
Parameters
account_to_modify: the name or id of the account to update
voting_account: the name or id of an account authorized to vote account_to_modify’s shares, or null to vote your own shares
broadcast: true if you wish to broadcast the transaction
     * 
    */

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class SetVotingProxyCreateOrUpdate
    {
        public SetVotingProxyCreateOrUpdate()
        {           
        }

        [DataMember(Name= "accountToModify")]
        public string AccountToModify { get; set; }

        [DataMember(Name= "votingAccount")]
        public string VotingAccount { get; set; }

        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;
    }
}
