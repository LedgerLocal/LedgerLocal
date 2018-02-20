using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Shoppingcartcouponmap
    {
        public int Shoppingcartcouponid { get; set; }
        public int Couponrepositoryid { get; set; }
        public int Shoppingcartid { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Couponrepository Couponrepository { get; set; }
        public Shoppingcart Shoppingcart { get; set; }
    }
}
