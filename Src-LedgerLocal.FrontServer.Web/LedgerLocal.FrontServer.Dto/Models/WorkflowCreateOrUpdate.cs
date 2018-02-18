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
    public partial class WorkflowCreateOrUpdate
    {
        
        [DataMember(Name="workflowId")]
        public string WorkflowId { get; set; }

        [DataMember(Name = "workflowTypeId")]
        public string WorkflowTypeId { get; set; }

        [DataMember(Name="categoryId")]
        public string CategoryId { get; set; }

        [DataMember(Name = "cultureId")]
        public string CultureId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "body")]
        public string Body { get; set; }

        [DataMember(Name = "isComponent")]
        public bool IsComponent { get; set; }

        [DataMember(Name = "isEntryPoint")]
        public bool IsEntryPoint { get; set; }

        [DataMember(Name = "hasArguments")]
        public bool HasArguments { get; set; }

        [DataMember(Name = "arguments")]
        public Dictionary<string, object> Arguments { get; set; }

        [DataMember(Name = "timeStamp")]
        public DateTime Timestamp { get; set; }

    }
}
