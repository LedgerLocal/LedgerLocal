using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Sale
    {
        public Sale()
        {
            Couponrepository = new HashSet<Couponrepository>();
            Saleattributemap = new HashSet<Saleattributemap>();
            Salecategorymap = new HashSet<Salecategorymap>();
            Saleproductmap = new HashSet<Saleproductmap>();
        }

        public int Saleid { get; set; }
        public string Name { get; set; }
        public bool? Allowunrestrictedscope { get; set; }
        public bool? Ispercentsale { get; set; }
        public decimal? Dicountpercent { get; set; }
        public decimal? Amount { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public bool? Activate { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Couponrepository> Couponrepository { get; set; }
        public ICollection<Saleattributemap> Saleattributemap { get; set; }
        public ICollection<Salecategorymap> Salecategorymap { get; set; }
        public ICollection<Saleproductmap> Saleproductmap { get; set; }
    }
}
