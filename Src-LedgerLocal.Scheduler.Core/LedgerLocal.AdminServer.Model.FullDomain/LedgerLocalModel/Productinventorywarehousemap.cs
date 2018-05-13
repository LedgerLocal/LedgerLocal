using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Productinventorywarehousemap
    {
        public int Productinventorymapid { get; set; }
        public int? Productinventoryid { get; set; }
        public int? Productwarehouseid { get; set; }
        public long? Reorderlevel { get; set; }
        public long? Quantityavailableforsale { get; set; }
        public decimal Reorderpoint { get; set; }
        public decimal Quantityreserved { get; set; }
        public decimal Quantityoutofstockpoint { get; set; }
        public decimal Quantityavailable { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Productinventory Productinventory { get; set; }
        public Productwarehouse Productwarehouse { get; set; }
    }
}
