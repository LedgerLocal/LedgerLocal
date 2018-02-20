using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Taxweee
    {
        public Taxweee()
        {
            Productculturemap = new HashSet<Productculturemap>();
        }

        public int Taxweeeid { get; set; }
        public decimal Subamount { get; set; }
        public decimal? Amount { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Productculturemap> Productculturemap { get; set; }
    }
}
