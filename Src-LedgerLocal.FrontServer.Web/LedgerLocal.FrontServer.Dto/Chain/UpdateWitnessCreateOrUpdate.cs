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
    public partial class UpdateWitnessCreateOrUpdate
    {

        /*

witness: The name of the witness’s owner account. Also accepts the ID of the owner account or the ID of the witness.
url: Same as for create_witness. The empty string makes it remain the same.
block_signing_key: The new block signing public key. The empty string makes it remain the same.
broadcast: true if you wish to broadcast the transaction.

         */

        public UpdateWitnessCreateOrUpdate()
        {
                        
        }

        [DataMember(Name = "witness")]
        public string Witness { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "blockSigningKey")]
        public string BlockSigningKey { get; set; }

        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;

    }
}
