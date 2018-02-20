using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Suppliertype
    {
        public Suppliertype()
        {
            Supplier = new HashSet<Supplier>();
        }

        public int Suppliertypeid { get; set; }
        public string Name { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Supplier> Supplier { get; set; }
    }
}
