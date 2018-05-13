using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Subproductattributemap
    {
        public int Subproductattributemapid { get; set; }
        public int? Attributeid { get; set; }
        public int? Productid { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Attribute Attribute { get; set; }
        public Product Product { get; set; }
    }
}
