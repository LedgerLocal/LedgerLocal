using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Postalzonecountrymap
    {
        public int Postalzonecountryid { get; set; }
        public int? Countryid { get; set; }
        public int? Postalzoneid { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Country Country { get; set; }
        public Postalzone Postalzone { get; set; }
    }
}
