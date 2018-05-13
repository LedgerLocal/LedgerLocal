using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Productgroup
    {
        public Productgroup()
        {
            Product = new HashSet<Product>();
        }

        public int Productgroupid { get; set; }
        public string Name { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
