using System;
using System.Runtime.Serialization;

namespace LedgerLocal.FrontServer.Dto
{

    [DataContract]
    public partial class PolicyCreateOrUpdate
    {

        [DataMember(Name = "policyGenericAttributeId")]
        public string PolicyGenericAttributeId { get; set; }

        [DataMember(Name = "genericAttributeId")]
        public string GenericAttributeId { get; set; }

        [DataMember(Name="name")]
        public string Name { get; set; }

        [DataMember(Name= "timestamp")]
        public DateTime Timestamp { get; set; }

        [DataMember(Name = "keyValue")]
        public string KeyValue { get; set; }

        [DataMember(Name = "itemValue")]
        public object ItemValue { get; set; }

    }
}
