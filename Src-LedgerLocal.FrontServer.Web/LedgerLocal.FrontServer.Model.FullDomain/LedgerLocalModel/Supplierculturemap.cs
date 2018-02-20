using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Supplierculturemap
    {
        public int Supplierculturemapid { get; set; }
        public int? Cultureid { get; set; }
        public int? Supplierid { get; set; }
        public string Shortdescription { get; set; }
        public string Description { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Culture Culture { get; set; }
        public Supplier Supplier { get; set; }
    }
}
