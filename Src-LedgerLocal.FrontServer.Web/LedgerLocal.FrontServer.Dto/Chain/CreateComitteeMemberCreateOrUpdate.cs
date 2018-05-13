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
    public partial class CreateComitteeMemberCreateOrUpdate
    {

        /*
         
owner_account: the name or id of the account which is creating the committee_member
url: a URL to include in the committee_member record in the blockchain. Clients may display this when showing a list of committee_members. May be blank.
broadcast: true to broadcast the transaction on the network

         */

        public CreateComitteeMemberCreateOrUpdate()
        {
            
        }

        [DataMember(Name = "ownerAccount")]
        public string OwnerAccount { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }
        
        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;

    }
}
