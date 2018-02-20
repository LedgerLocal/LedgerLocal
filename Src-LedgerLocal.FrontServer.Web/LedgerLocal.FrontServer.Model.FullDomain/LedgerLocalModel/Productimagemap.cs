using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Productimagemap
    {
        public int Productimageid { get; set; }
        public int Productid { get; set; }
        public int Imageid { get; set; }
        public int? Productimagetypeid { get; set; }
        public bool Activate { get; set; }
        public int Sort { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Image Image { get; set; }
        public Product Product { get; set; }
        public Productimagetype Productimagetype { get; set; }
    }
}
