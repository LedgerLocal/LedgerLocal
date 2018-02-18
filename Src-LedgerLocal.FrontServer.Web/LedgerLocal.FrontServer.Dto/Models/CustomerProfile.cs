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

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class CustomerProfile
    {
        public CustomerProfile()
        { }

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
        /// Gets or Sets Firstlogin
        /// </summary>
        [DataMember(Name="firstlogin")]
        public DateTime? Firstlogin { get; set; }
        /// <summary>
        /// Gets or Sets Lastlogin
        /// </summary>
        [DataMember(Name="lastlogin")]
        public DateTime? Lastlogin { get; set; }
        /// <summary>
        /// Gets or Sets RegistrationDate
        /// </summary>
        [DataMember(Name="registrationDate")]
        public DateTime? RegistrationDate { get; set; }
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
        /// <summary>
        /// Gets or Sets Active
        /// </summary>
        [DataMember(Name="active")]
        public bool? Active { get; set; }
        
    }
}
