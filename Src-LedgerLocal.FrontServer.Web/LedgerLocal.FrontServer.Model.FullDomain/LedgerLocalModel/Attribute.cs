using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Attribute
    {
        public Attribute()
        {
            Attributeevent = new HashSet<Attributeevent>();
            Productattributemap = new HashSet<Productattributemap>();
            Saleattributemap = new HashSet<Saleattributemap>();
            Subproductattributemap = new HashSet<Subproductattributemap>();
        }

        public int Attributeid { get; set; }
        public int Attributetypeid { get; set; }
        public int Attributeitemid { get; set; }
        public decimal? Adjustment { get; set; }
        public string Skusuffix { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Attributeitem Attributeitem { get; set; }
        public Attributetype Attributetype { get; set; }
        public ICollection<Attributeevent> Attributeevent { get; set; }
        public ICollection<Productattributemap> Productattributemap { get; set; }
        public ICollection<Saleattributemap> Saleattributemap { get; set; }
        public ICollection<Subproductattributemap> Subproductattributemap { get; set; }
    }
}
