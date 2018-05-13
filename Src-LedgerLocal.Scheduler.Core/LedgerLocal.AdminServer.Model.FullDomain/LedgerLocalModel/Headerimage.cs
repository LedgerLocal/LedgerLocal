using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Headerimage
    {
        public int Headerimageid { get; set; }
        public int? Headerimagetypeid { get; set; }
        public int? Imageid { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Headerimagetype Headerimagetype { get; set; }
        public Image Image { get; set; }
    }
}
