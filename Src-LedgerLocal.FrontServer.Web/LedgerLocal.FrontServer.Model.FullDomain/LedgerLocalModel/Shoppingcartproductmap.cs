using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Shoppingcartproductmap
    {
        public int Shoppingcartproductmapid { get; set; }
        public int? Shoppingcartid { get; set; }
        public int? Productid { get; set; }
        public int Quantity { get; set; }
        public decimal? Unitprice { get; set; }
        public decimal? Totalprice { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Product Product { get; set; }
        public Shoppingcart Shoppingcart { get; set; }
    }
}
