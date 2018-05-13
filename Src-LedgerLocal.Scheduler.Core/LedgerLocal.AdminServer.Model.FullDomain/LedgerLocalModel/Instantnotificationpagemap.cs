using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Instantnotificationpagemap
    {
        public int Instantnotificationpageid { get; set; }
        public int Pageid { get; set; }
        public int Instantnotificationid { get; set; }
        public bool Activate { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Instantnotification Instantnotification { get; set; }
        public Page Page { get; set; }
    }
}
