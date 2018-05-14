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

    [DataContract]
    public partial class ActionEventDefinition
    {

        [DataMember(Name= "actionName")]
        public string ActionName { get; set; }

        [DataMember(Name="message")]
        public string Message { get; set; }

        [DataMember(Name="timestamp")]
        public DateTime? Timestamp { get; set; }

        [DataMember(Name="success")]
        public bool? Success { get; set; }

        [DataMember(Name = "reason")]
        public string Reason { get; set; }

    }
}
