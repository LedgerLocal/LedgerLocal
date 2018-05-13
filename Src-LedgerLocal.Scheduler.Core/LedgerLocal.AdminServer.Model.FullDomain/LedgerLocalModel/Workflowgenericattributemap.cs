using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Workflowgenericattributemap
    {
        public int Workflowgenericattributeid { get; set; }
        public int? Workflowcontainerid { get; set; }
        public int? Genericattributeid { get; set; }
        public bool? Active { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Genericattribute Genericattribute { get; set; }
        public Workflowcontainer Workflowcontainer { get; set; }
    }
}
