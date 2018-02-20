using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Inventorystatus
    {
        public Inventorystatus()
        {
            Productinventory = new HashSet<Productinventory>();
        }

        public int Inventorystatusid { get; set; }
        public string Description { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Productinventory> Productinventory { get; set; }
    }
}
