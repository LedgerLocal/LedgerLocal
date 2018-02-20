using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Productinventory
    {
        public Productinventory()
        {
            Inventoryrecord = new HashSet<Inventoryrecord>();
            Productinventorywarehousemap = new HashSet<Productinventorywarehousemap>();
            Stockmanagment = new HashSet<Stockmanagment>();
        }

        public int Productinventoryid { get; set; }
        public int? Inventorystatusid { get; set; }
        public decimal Quantityavailable { get; set; }
        public decimal Quantityoutofstockpoint { get; set; }
        public decimal Quantityreserved { get; set; }
        public decimal Reorderpoint { get; set; }
        public long? Quantityavailableforsale { get; set; }
        public long? Reorderlevel { get; set; }
        public int Outofstockmode { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Inventorystatus Inventorystatus { get; set; }
        public ICollection<Inventoryrecord> Inventoryrecord { get; set; }
        public ICollection<Productinventorywarehousemap> Productinventorywarehousemap { get; set; }
        public ICollection<Stockmanagment> Stockmanagment { get; set; }
    }
}
