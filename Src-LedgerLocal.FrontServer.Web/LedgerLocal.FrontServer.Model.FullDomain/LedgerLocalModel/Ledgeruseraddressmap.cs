using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Ledgeruseraddressmap
    {
        public int Ledgeruseraddressmapid { get; set; }
        public int? Currencyid { get; set; }
        public int? Userid { get; set; }
        public string Address { get; set; }
        public string Memobc { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Currency Currency { get; set; }
        public User User { get; set; }
    }
}
