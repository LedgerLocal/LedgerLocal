using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Orderitempackagemap
    {
        public int Orderitempackageid { get; set; }
        public int Orderpackageid { get; set; }
        public int Orderitemid { get; set; }
        public int Quantitypackaged { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Orderitem Orderitem { get; set; }
        public Orderpackage Orderpackage { get; set; }
    }
}
