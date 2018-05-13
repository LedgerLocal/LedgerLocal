using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Supplierimagemap
    {
        public int Supplierimageid { get; set; }
        public int? Supplierid { get; set; }
        public int? Imageid { get; set; }
        public int? Supplierimagetypeid { get; set; }
        public bool Activate { get; set; }
        public int? Sort { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Image Image { get; set; }
        public Supplier Supplier { get; set; }
        public Supplierimagetype Supplierimagetype { get; set; }
    }
}
