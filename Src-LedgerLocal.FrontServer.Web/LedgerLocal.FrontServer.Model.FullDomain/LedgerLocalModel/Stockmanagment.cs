using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Stockmanagment
    {
        public Stockmanagment()
        {
            Product = new HashSet<Product>();
        }

        public int Stockmanagmentid { get; set; }
        public int? Stockmanagmenttypeid { get; set; }
        public int? Productinventoryid { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Productinventory Productinventory { get; set; }
        public Stockmanagmenttype Stockmanagmenttype { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
