using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Dreamimage
    {
        public Dreamimage()
        {
            Dreamproductimagemap = new HashSet<Dreamproductimagemap>();
        }

        public int Dreamimageid { get; set; }
        public string Fullimageurl { get; set; }
        public string Thumburl { get; set; }
        public string Caption { get; set; }
        public int? Imagetypeid { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Imagetype Imagetype { get; set; }
        public ICollection<Dreamproductimagemap> Dreamproductimagemap { get; set; }
    }
}
