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
    public partial class GetKeyLabelCreateOrUpdate
    {

        /*
         
string graphene::wallet::wallet_api::get_key_label(public_key_type key) const

         */

        public GetKeyLabelCreateOrUpdate()
        {
            
        }

        [DataMember(Name = "publicKey")]
        public PublicKeyCreateOrUpdate PublicKey { get; set; }

       

    }
}
