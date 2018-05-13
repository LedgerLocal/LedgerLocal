using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace LedgerLocal.AdminServer.Api.Web.Models
{
    [DataContract]
    public partial class CustomerCreateOrUpdate
    {
        public CustomerCreateOrUpdate()
        {           
        }

        [DataMember(Name="customerId")]
        public string CustomerId { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name="firstName")]
        public string FirstName { get; set; }

        [DataMember(Name="lastName")]
        public string LastName { get; set; }

        [DataMember(Name = "address1")]
        public string Address1 { get; set; }

        [DataMember(Name = "address2")]
        public string Address2 { get; set; }

        [DataMember(Name = "country")]
        public string Country { get; set; }



    }
}
