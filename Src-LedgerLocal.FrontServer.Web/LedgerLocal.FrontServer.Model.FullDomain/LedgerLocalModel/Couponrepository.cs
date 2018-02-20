using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Couponrepository
    {
        public Couponrepository()
        {
            Ordercouponmap = new HashSet<Ordercouponmap>();
            Shoppingcartcouponmap = new HashSet<Shoppingcartcouponmap>();
        }

        public int Couponrepositoryid { get; set; }
        public int? Saleid { get; set; }
        public long? Qrcoderepositoryid { get; set; }
        public long? Coinledgerid { get; set; }
        public char Couponcode { get; set; }
        public string Name { get; set; }
        public bool? Unlimited { get; set; }
        public DateTime? Dateused { get; set; }
        public string Note { get; set; }
        public bool Activate { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public int? Iotdeviceid { get; set; }

        public Sale Sale { get; set; }
        public ICollection<Ordercouponmap> Ordercouponmap { get; set; }
        public ICollection<Shoppingcartcouponmap> Shoppingcartcouponmap { get; set; }
    }
}
