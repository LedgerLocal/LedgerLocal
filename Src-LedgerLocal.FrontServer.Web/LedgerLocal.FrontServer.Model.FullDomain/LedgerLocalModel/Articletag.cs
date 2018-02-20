using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Articletag
    {
        public Articletag()
        {
            Articletagmap = new HashSet<Articletagmap>();
        }

        public int Articletagid { get; set; }
        public bool Isprivate { get; set; }
        public string Tagname { get; set; }
        public bool Activate { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Articletagmap> Articletagmap { get; set; }
    }
}
