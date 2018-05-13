using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Shoppingcartbehavior
    {
        public Shoppingcartbehavior()
        {
            Shoppingcartevent = new HashSet<Shoppingcartevent>();
        }

        public int Shoppingcartbehaviorid { get; set; }
        public string Description { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Shoppingcartevent> Shoppingcartevent { get; set; }
    }
}
