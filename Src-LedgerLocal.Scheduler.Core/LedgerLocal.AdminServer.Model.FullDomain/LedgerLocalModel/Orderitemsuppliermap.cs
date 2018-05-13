using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Orderitemsuppliermap
    {
        public int Orderitemsuppliermapid { get; set; }
        public int Ordersupplierid { get; set; }
        public int Productid { get; set; }
        public decimal Unitprice { get; set; }
        public decimal? Totalprice { get; set; }
        public int Quantity { get; set; }
        public int? Realquantity { get; set; }
        public bool Validate { get; set; }
        public string Note { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Ordersupplier Ordersupplier { get; set; }
        public Product Product { get; set; }
    }
}
