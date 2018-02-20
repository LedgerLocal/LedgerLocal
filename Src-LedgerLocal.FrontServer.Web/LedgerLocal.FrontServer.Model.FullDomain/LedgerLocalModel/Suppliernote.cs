using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Suppliernote
    {
        public int Suppliernoteid { get; set; }
        public int? Supplierid { get; set; }
        public char Note { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Supplier Supplier { get; set; }
    }
}
