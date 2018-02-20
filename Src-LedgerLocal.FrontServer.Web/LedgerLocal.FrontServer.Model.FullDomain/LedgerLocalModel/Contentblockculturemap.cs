using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Contentblockculturemap
    {
        public int Contentblockculturemapid { get; set; }
        public int? Contentblockid { get; set; }
        public int? Cultureid { get; set; }
        public string Content { get; set; }
        public bool Activate { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Contentblock Contentblock { get; set; }
        public Culture Culture { get; set; }
    }
}
