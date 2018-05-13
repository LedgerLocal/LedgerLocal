using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Policy
    {
        public Policy()
        {
            Policyculturemap = new HashSet<Policyculturemap>();
        }

        public int Policyid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Activate { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Policyculturemap> Policyculturemap { get; set; }
    }
}
