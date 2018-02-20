using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Productwarehouse
    {
        public Productwarehouse()
        {
            Inventoryrecord = new HashSet<Inventoryrecord>();
            Ordersupplier = new HashSet<Ordersupplier>();
            Productinventorywarehousemap = new HashSet<Productinventorywarehousemap>();
        }

        public int Productwarehouseid { get; set; }
        public int? Addressid { get; set; }
        public string Name { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Address Address { get; set; }
        public ICollection<Inventoryrecord> Inventoryrecord { get; set; }
        public ICollection<Ordersupplier> Ordersupplier { get; set; }
        public ICollection<Productinventorywarehousemap> Productinventorywarehousemap { get; set; }
    }
}
