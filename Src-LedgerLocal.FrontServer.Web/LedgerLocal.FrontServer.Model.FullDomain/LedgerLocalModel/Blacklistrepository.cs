using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Blacklistrepository
    {
        public int Blacklistrepoditoryid { get; set; }
        public string Ip { get; set; }
        public DateTime Dateblacklisted { get; set; }
        public int? Dayblacklisted { get; set; }
        public string Note { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
    }
}
