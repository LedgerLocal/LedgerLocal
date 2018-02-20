using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Pageimagetype
    {
        public Pageimagetype()
        {
            Pageimagemap = new HashSet<Pageimagemap>();
        }

        public int Pageimagetypeid { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Pageimagemap> Pageimagemap { get; set; }
    }
}
