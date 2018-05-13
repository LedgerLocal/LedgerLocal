using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Peopleonlinehistory
    {
        public int Peopleonlinehistoryid { get; set; }
        public int? Userid { get; set; }
        public string Ip { get; set; }
        public string Browser { get; set; }
        public DateTime Firstactivity { get; set; }
        public DateTime? Endactivity { get; set; }
        public decimal? Durationminute { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public User User { get; set; }
    }
}
