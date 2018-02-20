using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Currency
    {
        public Currency()
        {
            Ledgeruseraddressmap = new HashSet<Ledgeruseraddressmap>();
            Transactions = new HashSet<Transactions>();
        }

        public int Currencyid { get; set; }
        public string Name { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Ledgeruseraddressmap> Ledgeruseraddressmap { get; set; }
        public ICollection<Transactions> Transactions { get; set; }
    }
}
