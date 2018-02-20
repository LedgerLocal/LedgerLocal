using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Productbehavior
    {
        public Productbehavior()
        {
            Productevent = new HashSet<Productevent>();
        }

        public int Productbehaviorid { get; set; }
        public string Description { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Productevent> Productevent { get; set; }
    }
}
