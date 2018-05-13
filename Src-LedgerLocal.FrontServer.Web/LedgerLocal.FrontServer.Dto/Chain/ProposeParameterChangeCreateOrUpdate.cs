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
signed_transaction graphene::wallet::wallet_api::propose_parameter_change(const string &proposing_account, fc::time_point_sec expiration_time, const variant_object &changed_values, bool broadcast = false)
Creates a transaction to propose a parameter change.
Multiple parameters can be specified if an atomic change is desired.
Return
the signed version of the transaction
Parameters
proposing_account: The account paying the fee to propose the tx
expiration_time: Timestamp specifying when the proposal will either take effect or expire.
changed_values: The values to change; all other chain parameters are filled in with default values
broadcast: true if you wish to broadcast the transaction
     * 
    */

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ProposeParameterChangeCreateOrUpdate
    {
        public ProposeParameterChangeCreateOrUpdate()
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
