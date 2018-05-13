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
    public partial class WhitelistAccountCreateOrUpdate
    {

        public WhitelistAccountCreateOrUpdate()
        {
            
        }

        [DataMember(Name = "authorizingAccount")]
        public string AuthorizingAccount { get; set; }

        [DataMember(Name = "accountToList")]
        public string AccountToList { get; set; }

        [DataMember(Name = "listingStatus")]
        public string ListingStatus { get; set; }

        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;

    }
}
