using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LedgerLocal.Dto.Chain
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class UserProfile
    {
        public UserProfile()
        { }


        [DataMember(Name="customerId")]
        public string CustomerId { get; set; }

        [DataMember(Name="salutation")]
        public string Salutation { get; set; }

        [DataMember(Name="firstlogin")]
        public DateTime? Firstlogin { get; set; }

        [DataMember(Name="lastlogin")]
        public DateTime? Lastlogin { get; set; }

        [DataMember(Name="registrationDate")]
        public DateTime? RegistrationDate { get; set; }

        [DataMember(Name="firstName")]
        public string FirstName { get; set; }

        [DataMember(Name="lastName")]
        public string LastName { get; set; }

        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Email address of the LoyaltyCoin user
        /// </summary>
        /// <value>Email address of the LoyaltyCoin user</value>
        [DataMember(Name="email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets Active
        /// </summary>
        [DataMember(Name="active")]
        public bool? Active { get; set; }
        
    }
}
