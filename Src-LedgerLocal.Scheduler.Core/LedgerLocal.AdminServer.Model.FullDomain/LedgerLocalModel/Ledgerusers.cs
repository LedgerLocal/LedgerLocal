using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Ledgerusers
    {
        public int Bitsharesaccountid { get; set; }
        public int? Userid { get; set; }
        public string Bitsharesaccount { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public User User { get; set; }
    }
}
