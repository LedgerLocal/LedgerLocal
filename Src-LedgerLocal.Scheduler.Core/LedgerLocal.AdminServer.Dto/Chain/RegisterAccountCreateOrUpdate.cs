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
    public partial class RegisterAccountCreateOrUpdate
    {

        public RegisterAccountCreateOrUpdate()
        {
            
        }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "owner")]
        public PublicKeyDescription Owner { get; set; }

        [DataMember(Name = "active")]
        public PublicKeyDescription Active { get; set; }

        [DataMember(Name = "registrarAccount")]
        public string RegistrarAccount { get; set; }

        [DataMember(Name = "referrerAccount")]
        public string ReferrerAccount { get; set; }

        [DataMember(Name = "referrerPercent")]
        public int ReferrerPercent { get; set; }

        [DataMember(Name = "broadcast")]
        public bool Broadcast { get; set; } = false;

    }
}
