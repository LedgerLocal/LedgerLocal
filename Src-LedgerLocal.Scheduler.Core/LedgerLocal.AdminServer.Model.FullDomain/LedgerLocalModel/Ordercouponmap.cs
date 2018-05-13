using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Ordercouponmap
    {
        public int Ordercouponid { get; set; }
        public int Couponrepositoryid { get; set; }
        public int Orderid { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Couponrepository Couponrepository { get; set; }
        public Order Order { get; set; }
    }
}
