using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Categoryimagemap
    {
        public int Categoryimageid { get; set; }
        public int Imageid { get; set; }
        public int Categoryid { get; set; }
        public bool Activate { get; set; }
        public int Sort { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Category Category { get; set; }
        public Image Image { get; set; }
    }
}
