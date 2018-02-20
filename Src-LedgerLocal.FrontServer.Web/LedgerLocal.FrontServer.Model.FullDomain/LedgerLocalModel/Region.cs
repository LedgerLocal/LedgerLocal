using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Region
    {
        public Region()
        {
            City = new HashSet<City>();
            Postalcode = new HashSet<Postalcode>();
            ShippingmethodrateFromregion = new HashSet<Shippingmethodrate>();
            ShippingmethodrateToregion = new HashSet<Shippingmethodrate>();
            Taxrate = new HashSet<Taxrate>();
        }

        public int Regionid { get; set; }
        public int? Countryid { get; set; }
        public string Region1 { get; set; }
        public string Regioncode { get; set; }
        public string Adm1code { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Country Country { get; set; }
        public ICollection<City> City { get; set; }
        public ICollection<Postalcode> Postalcode { get; set; }
        public ICollection<Shippingmethodrate> ShippingmethodrateFromregion { get; set; }
        public ICollection<Shippingmethodrate> ShippingmethodrateToregion { get; set; }
        public ICollection<Taxrate> Taxrate { get; set; }
    }
}
