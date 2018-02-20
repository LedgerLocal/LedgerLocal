using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Peopleonline
    {
        public int Peopleonlineid { get; set; }
        public int? Userid { get; set; }
        public string Ip { get; set; }
        public string Browser { get; set; }
        public DateTime Lastactivity { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public User User { get; set; }
    }
}
