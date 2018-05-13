using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Csvdelimiter
    {
        public Csvdelimiter()
        {
            Customexport = new HashSet<Customexport>();
        }

        public int Csvdelimiterid { get; set; }
        public string Delimiter { get; set; }
        public string Name { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Customexport> Customexport { get; set; }
    }
}
