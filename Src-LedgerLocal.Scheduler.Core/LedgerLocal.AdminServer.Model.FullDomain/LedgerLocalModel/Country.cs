using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Country
    {
        public Country()
        {
            City = new HashSet<City>();
            Postalcode = new HashSet<Postalcode>();
            Postalzonecountrymap = new HashSet<Postalzonecountrymap>();
            Region = new HashSet<Region>();
            ShippingmethodrateFromcountry = new HashSet<Shippingmethodrate>();
            ShippingmethodrateTocountry = new HashSet<Shippingmethodrate>();
            Taxrate = new HashSet<Taxrate>();
        }

        public int Countryid { get; set; }
        public int? Continentid { get; set; }
        public int? Geonameid { get; set; }
        public string Country1 { get; set; }
        public string Fips104 { get; set; }
        public string Iso2 { get; set; }
        public string Iso3 { get; set; }
        public string Ison { get; set; }
        public string Internet { get; set; }
        public string Capital { get; set; }
        public string Mapreference { get; set; }
        public string Nationalitysingular { get; set; }
        public string Nationalityplural { get; set; }
        public string Currency { get; set; }
        public string Currencycode { get; set; }
        public int? Population { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Continent Continent { get; set; }
        public ICollection<City> City { get; set; }
        public ICollection<Postalcode> Postalcode { get; set; }
        public ICollection<Postalzonecountrymap> Postalzonecountrymap { get; set; }
        public ICollection<Region> Region { get; set; }
        public ICollection<Shippingmethodrate> ShippingmethodrateFromcountry { get; set; }
        public ICollection<Shippingmethodrate> ShippingmethodrateTocountry { get; set; }
        public ICollection<Taxrate> Taxrate { get; set; }
    }
}
