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
    public partial class CreateAccountCreateOrUpdate
    {

        public CreateAccountCreateOrUpdate()
        {
            
        }

        [DataMember(Name = "brainKey")]
        public string BrainKey { get; set; }

        [DataMember(Name = "accountName")]
        public string AccountName { get; set; }

        [DataMember(Name = "registrarAccount")]
        public string RegistrarAccount { get; set; }

        [DataMember(Name = "referrerAccount")]
        public string ReferrerAccount { get; set; }

        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;

    }
}
