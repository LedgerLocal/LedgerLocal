using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Shippingmethodrate
    {
        public int Shippingmethodrateid { get; set; }
        public int? Shippingmethodid { get; set; }
        public int? Frompostalzoneid { get; set; }
        public int? Topostalzoneid { get; set; }
        public int? Fromcountryid { get; set; }
        public int? Tocountryid { get; set; }
        public int? Fromregionid { get; set; }
        public int? Toregionid { get; set; }
        public int? Frompostalcodeid { get; set; }
        public int? Topostalcodeid { get; set; }
        public int? Tocontinentid { get; set; }
        public int? Fromcontinentid { get; set; }
        public decimal Weightmin { get; set; }
        public decimal Weightmax { get; set; }
        public decimal Rate { get; set; }
        public int Estimateddelivery { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Continent Fromcontinent { get; set; }
        public Country Fromcountry { get; set; }
        public Postalcode Frompostalcode { get; set; }
        public Postalzone Frompostalzone { get; set; }
        public Region Fromregion { get; set; }
        public Shippingmethod Shippingmethod { get; set; }
        public Continent Tocontinent { get; set; }
        public Country Tocountry { get; set; }
        public Postalcode Topostalcode { get; set; }
        public Postalzone Topostalzone { get; set; }
        public Region Toregion { get; set; }
    }
}
