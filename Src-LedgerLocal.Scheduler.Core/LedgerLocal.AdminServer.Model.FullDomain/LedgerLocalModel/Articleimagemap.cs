using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Articleimagemap
    {
        public int Articleimageid { get; set; }
        public int Articleid { get; set; }
        public int Imageid { get; set; }
        public bool Activate { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Article Article { get; set; }
        public Image Image { get; set; }
    }
}
