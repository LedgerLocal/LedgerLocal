using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Orderpackage
    {
        public Orderpackage()
        {
            Orderitempackagemap = new HashSet<Orderitempackagemap>();
        }

        public int Orderpackageid { get; set; }
        public int? Orderid { get; set; }
        public int? Shippingmethodid { get; set; }
        public char? Description { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public decimal? Length { get; set; }
        public decimal Weight { get; set; }
        public bool Hasshipped { get; set; }
        public string Trackingnumber { get; set; }
        public DateTime? Shipdate { get; set; }
        public long Timeintransit { get; set; }
        public decimal Estimatedshippingcost { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Order Order { get; set; }
        public Shippingmethod Shippingmethod { get; set; }
        public ICollection<Orderitempackagemap> Orderitempackagemap { get; set; }
    }
}
