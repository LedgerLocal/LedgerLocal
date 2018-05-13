using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Tokenprice
    {
        public int Tokenpriceid { get; set; }
        public bool? Fullysold { get; set; }
        public decimal? Priceusd { get; set; }
        public long? Remainingtokens { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
    }
}
