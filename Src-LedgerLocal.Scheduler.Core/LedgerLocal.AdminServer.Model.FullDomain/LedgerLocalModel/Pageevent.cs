using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Pageevent
    {
        public int Pageeventid { get; set; }
        public int Pagebehaviorid { get; set; }
        public int? Userid { get; set; }
        public int Pageculturemapid { get; set; }
        public DateTime Eventdate { get; set; }
        public string Ip { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Pagebehavior Pagebehavior { get; set; }
        public Pageculturemap Pageculturemap { get; set; }
        public User User { get; set; }
    }
}
