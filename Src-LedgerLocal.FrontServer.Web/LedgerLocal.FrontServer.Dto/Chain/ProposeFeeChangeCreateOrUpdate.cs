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
signed_transaction graphene::wallet::wallet_api::propose_fee_change(const string &proposing_account, fc::time_point_sec expiration_time, const variant_object &changed_values, bool broadcast = false)
Propose a fee change.
Return
the signed version of the transaction
Parameters
proposing_account: The account paying the fee to propose the tx
expiration_time: Timestamp specifying when the proposal will either take effect or expire.
changed_values: Map of operation type to new fee. Operations may be specified by name or ID. The “scale” key changes the scale. All other operations will maintain current values.
broadcast: true if you wish to broadcast the transaction
     * 
    */

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ProposeFeeChangeCreateOrUpdate
    {
        public ProposeFeeChangeCreateOrUpdate()
        {
            ChangedValues = new Dictionary<string, object>();
        }

        [DataMember(Name = "proposingAccount")]
        public string ProposingAccount { get; set; }

        [DataMember(Name = "expirationTime")]
        public DateTime ExpirationTime { get; set; }

        [DataMember(Name = "changedValues")]
        public Dictionary<string, object> ChangedValues { get; set; }

        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;
    }
}
