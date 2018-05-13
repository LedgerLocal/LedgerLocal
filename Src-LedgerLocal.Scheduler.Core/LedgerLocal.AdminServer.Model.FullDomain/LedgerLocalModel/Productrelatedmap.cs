using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Productrelatedmap
    {
        public int Productrelatedid { get; set; }
        public int Productid { get; set; }
        public int Relatedproductid { get; set; }
        public bool? Activate { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Product Product { get; set; }
        public Product Relatedproduct { get; set; }
    }
}
