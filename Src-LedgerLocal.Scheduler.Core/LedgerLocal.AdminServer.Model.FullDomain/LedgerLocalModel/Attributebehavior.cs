using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Attributebehavior
    {
        public Attributebehavior()
        {
            Attributeevent = new HashSet<Attributeevent>();
        }

        public int Attributebehaviorid { get; set; }
        public string Description { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Attributeevent> Attributeevent { get; set; }
    }
}
