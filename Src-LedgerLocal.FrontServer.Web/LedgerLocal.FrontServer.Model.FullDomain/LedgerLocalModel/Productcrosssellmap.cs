using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Productcrosssellmap
    {
        public int Productcrosssellid { get; set; }
        public int Productid { get; set; }
        public int Crossproductid { get; set; }
        public int? Orderid { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Product Crossproduct { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
