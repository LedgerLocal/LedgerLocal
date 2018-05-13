using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Deliverymethod
    {
        public Deliverymethod()
        {
            Product = new HashSet<Product>();
        }

        public int Deliverymethodid { get; set; }
        public string Description { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
