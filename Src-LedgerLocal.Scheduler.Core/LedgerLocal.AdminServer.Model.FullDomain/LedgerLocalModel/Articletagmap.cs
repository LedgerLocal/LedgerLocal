using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Articletagmap
    {
        public int Articletagmapid { get; set; }
        public int Articleid { get; set; }
        public int Articletagid { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Article Article { get; set; }
        public Articletag Articletag { get; set; }
    }
}
