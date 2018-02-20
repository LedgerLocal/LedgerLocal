using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Imagetype
    {
        public Imagetype()
        {
            Dreamimage = new HashSet<Dreamimage>();
            Image = new HashSet<Image>();
        }

        public int Imagetypeid { get; set; }
        public string Name { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Dreamimage> Dreamimage { get; set; }
        public ICollection<Image> Image { get; set; }
    }
}
