using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace LedgerLocal.FrontServer.Api.Web.Models
{
    [DataContract]
    public partial class CustomerCreateOrUpdate
    {
        public CustomerCreateOrUpdate()
        {           
        }

        /// <summary>
        /// Gets or Sets CustomerId
        /// </summary>
        [DataMember(Name="customerId")]
        public string CustomerId { get; set; }
        /// <summary>
        /// Gets or Sets Salutation
        /// </summary>
        [DataMember(Name="salutation")]
        public string Salutation { get; set; }
        /// <summary>
        /// First name of the LedgerLocal user.
        /// </summary>
        /// <value>First name of the LedgerLocal user.</value>
        [DataMember(Name="firstName")]
        public string FirstName { get; set; }
        /// <summary>
        /// Last name of the LedgerLocal user.
        /// </summary>
        /// <value>Last name of the LedgerLocal user.</value>
        [DataMember(Name="lastName")]
        public string LastName { get; set; }
        /// <summary>
        /// Email address of the LedgerLocal user
        /// </summary>
        /// <value>Email address of the LedgerLocal user</value>
        [DataMember(Name="email")]
        public string Email { get; set; }
        /// <summary>
        /// Image URL of the LedgerLocal user.
        /// </summary>
        /// <value>Image URL of the LedgerLocal user.</value>
        [DataMember(Name="picture")]
        public string Picture { get; set; }
        
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
        

    }
}
