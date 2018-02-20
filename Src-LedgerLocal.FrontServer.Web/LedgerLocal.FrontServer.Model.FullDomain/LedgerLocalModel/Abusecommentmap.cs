using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Abusecommentmap
    {
        public int Abusecommentid { get; set; }
        public int Commentid { get; set; }
        public int Userid { get; set; }
        public bool? Isabuse { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Comment Comment { get; set; }
        public User User { get; set; }
    }
}
