using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace LedgerLocal.FrontServer.Api.Web.Models
{

    [DataContract]
    public partial class PolicyDescription
    {
        [DataMember(Name = "policyGenericAttributeId")]
        public string PolicyGenericAttributeId { get; set; }

        [DataMember(Name = "genericAttributeId")]
        public string GenericAttributeId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "timestamp")]
        public DateTime Timestamp { get; set; }

        [DataMember(Name = "keyValue")]
        public string KeyValue { get; set; }

        [DataMember(Name = "itemValue")]
        public object ItemValue { get; set; }

    }
}
