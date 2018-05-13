using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Programpointofsalemap
    {
        public int Programpointofsaleid { get; set; }
        public int? Pointofsaleid { get; set; }
        public int? Programid { get; set; }
        public int? Brandid { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
    }
}
