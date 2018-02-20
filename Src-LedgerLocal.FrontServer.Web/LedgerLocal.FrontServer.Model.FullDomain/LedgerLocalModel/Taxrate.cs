using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Taxrate
    {
        public int Taxrateid { get; set; }
        public int? Cityid { get; set; }
        public int? Regionid { get; set; }
        public int? Countryid { get; set; }
        public decimal Rate { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public City City { get; set; }
        public Country Country { get; set; }
        public Region Region { get; set; }
    }
}
