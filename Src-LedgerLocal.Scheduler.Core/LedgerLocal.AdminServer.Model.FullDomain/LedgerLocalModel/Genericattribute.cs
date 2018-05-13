using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Genericattribute
    {
        public Genericattribute()
        {
            Workflowgenericattributemap = new HashSet<Workflowgenericattributemap>();
        }

        public int Genericattributeid { get; set; }
        public int? Genericattributetypeid { get; set; }
        public int? Genericattributevalueid { get; set; }
        public string Typestring { get; set; }
        public string Typelabelstring { get; set; }
        public string Valuestring { get; set; }
        public string Valuelabelstring { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Genericattributetype Genericattributetype { get; set; }
        public Genericattributevalue Genericattributevalue { get; set; }
        public ICollection<Workflowgenericattributemap> Workflowgenericattributemap { get; set; }
    }
}
