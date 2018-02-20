using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Pageimagemap
    {
        public int Pageimageid { get; set; }
        public int? Imageid { get; set; }
        public int? Pageid { get; set; }
        public int? Pageimagetypeid { get; set; }
        public string Alt { get; set; }
        public int? Sort { get; set; }
        public bool? Activate { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Image Image { get; set; }
        public Page Page { get; set; }
        public Pageimagetype Pageimagetype { get; set; }
    }
}
