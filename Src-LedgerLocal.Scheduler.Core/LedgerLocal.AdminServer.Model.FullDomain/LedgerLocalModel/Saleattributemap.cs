using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Saleattributemap
    {
        public int Saleattributeid { get; set; }
        public int Saleid { get; set; }
        public int Attributeid { get; set; }
        public int Activate { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Attribute Attribute { get; set; }
        public Sale Sale { get; set; }
    }
}
