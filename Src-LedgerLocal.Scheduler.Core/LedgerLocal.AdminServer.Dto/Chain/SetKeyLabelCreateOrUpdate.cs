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
    public partial class SetKeyLabelCreateOrUpdate
    {

        /*
         
bool graphene::wallet::wallet_api::set_key_label(public_key_type key, string label)
These methods are used for stealth transfers This method can be used to set the label for a public key
Note
No two keys can have the same label.
Return
true if the label was set, otherwise false

         */

        public SetKeyLabelCreateOrUpdate()
        {
            
        }

        [DataMember(Name = "publicKey")]
        public PublicKeyCreateOrUpdate PublicKey { get; set; }

        [DataMember(Name = "label")]
        public string Label { get; set; }
        
    }
}
