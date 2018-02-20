using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Inventoryrecord
    {
        public int Inventoryrecordid { get; set; }
        public int? Productinventoryid { get; set; }
        public int? Productwarehouseid { get; set; }
        public int Increment { get; set; }
        public DateTime Dateentered { get; set; }
        public string Note { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Productinventory Productinventory { get; set; }
        public Productwarehouse Productwarehouse { get; set; }
    }
}
