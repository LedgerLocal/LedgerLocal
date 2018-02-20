using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Productsuppliermap
    {
        public int Productsupplierid { get; set; }
        public int Productid { get; set; }
        public int Supplierid { get; set; }
        public bool Activate { get; set; }
        public bool Isdefault { get; set; }
        public int? Estimateddelivery { get; set; }
        public int? Estimateddeliverymargin { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Product Product { get; set; }
        public Supplier Supplier { get; set; }
    }
}
