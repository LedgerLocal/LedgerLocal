using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Workflowcontainer
    {
        public Workflowcontainer()
        {
            Workflowgenericattributemap = new HashSet<Workflowgenericattributemap>();
        }

        public int Workflowcontainerid { get; set; }
        public int Workflowtypeid { get; set; }
        public int? Categoryid { get; set; }
        public int? Pointofsaleid { get; set; }
        public int? Programid { get; set; }
        public int Cultureid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public bool Iscomponent { get; set; }
        public bool Isentrypoint { get; set; }
        public bool Hasarguments { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Category Category { get; set; }
        public Workflowtype Workflowtype { get; set; }
        public ICollection<Workflowgenericattributemap> Workflowgenericattributemap { get; set; }
    }
}
