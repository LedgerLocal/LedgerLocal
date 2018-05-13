using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LedgerLocal.Dto.Chain
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class UserCreateOrUpdate
    {
        public UserCreateOrUpdate()
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

        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CustomerCreateOrUpdate {\n");
            sb.Append("  CustomerId: ").Append(CustomerId).Append("\n");
            sb.Append("  Salutation: ").Append(Salutation).Append("\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  LastName: ").Append(LastName).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Picture: ").Append(Picture).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
