using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Saleproductmap
    {
        public int Saleproductid { get; set; }
        public int Saleid { get; set; }
        public int Productid { get; set; }
        public int Activate { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Product Product { get; set; }
        public Sale Sale { get; set; }
    }
}
