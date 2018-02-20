using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Ordershippingmethodmap
    {
        public int Ordershippingmethodid { get; set; }
        public int? Orderid { get; set; }
        public int? Shippingmethodid { get; set; }
        public decimal? Discountamount { get; set; }
        public int Quantity { get; set; }
        public decimal? Unitprice { get; set; }
        public decimal? Unittaxprice { get; set; }
        public decimal? Totalprice { get; set; }
        public decimal? Totaltaxprice { get; set; }
        public decimal? Grandprice { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Order Order { get; set; }
        public Shippingmethod Shippingmethod { get; set; }
    }
}
