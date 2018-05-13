using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Workflowtype
    {
        public Workflowtype()
        {
            Workflowcontainer = new HashSet<Workflowcontainer>();
        }

        public int Workflowtypeid { get; set; }
        public int? Categoryid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Category Category { get; set; }
        public ICollection<Workflowcontainer> Workflowcontainer { get; set; }
    }
}
