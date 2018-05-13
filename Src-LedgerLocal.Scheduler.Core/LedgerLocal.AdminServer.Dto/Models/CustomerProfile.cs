using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace LedgerLocal.AdminServer.Api.Web.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class CustomerProfile
    {
        public CustomerProfile()
        { }

        [DataMember(Name = "customerId")]
        public string CustomerId { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        [DataMember(Name = "address1")]
        public string Address1 { get; set; }

        [DataMember(Name = "address2")]
        public string Address2 { get; set; }

        [DataMember(Name = "country")]
        public string Country { get; set; }

    }
}
