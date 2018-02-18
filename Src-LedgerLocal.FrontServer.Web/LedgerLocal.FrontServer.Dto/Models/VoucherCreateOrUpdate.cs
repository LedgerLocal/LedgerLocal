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
    public partial class VoucherCreateOrUpdate
    {

        public VoucherCreateOrUpdate()
        {
            Attributes = new Dictionary<string, object>();
        }

        [DataMember(Name="voucherId")]
        public string VoucherId { get; set; }

        [DataMember(Name = "voucherTypeId")]
        public string VoucherTypeId { get; set; }

        [DataMember(Name="coinId")]
        public string CoinId { get; set; }

        [DataMember(Name="customerId")]
        public string CustomerId { get; set; }

        [DataMember(Name = "genericAttributeId")]
        public string GenericAttributeId { get; set; }

        [DataMember(Name="name")]
        public string Name { get; set; }

        [DataMember(Name="label")]
        public string Label { get; set; }

        [DataMember(Name = "stringValue")]
        public string StringValue { get; set; }

        [DataMember(Name = "validFrom")]
        public DateTime? ValidFrom { get; set; }

        [DataMember(Name = "validTo")]
        public DateTime? ValidTo { get; set; }

        [DataMember(Name = "activate")]
        public bool Activate { get; set; }

        [DataMember(Name="timeStamp")]
        public DateTime Timestamp { get; set; }

        [DataMember(Name = "attributes")]
        public Dictionary<string, object> Attributes { get; set; }
    }
}
