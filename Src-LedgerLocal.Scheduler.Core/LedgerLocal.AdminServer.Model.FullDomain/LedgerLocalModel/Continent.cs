using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Continent
    {
        public Continent()
        {
            Country = new HashSet<Country>();
            ShippingmethodrateFromcontinent = new HashSet<Shippingmethodrate>();
            ShippingmethodrateTocontinent = new HashSet<Shippingmethodrate>();
        }

        public int Continentid { get; set; }
        public int? Geonameid { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Country> Country { get; set; }
        public ICollection<Shippingmethodrate> ShippingmethodrateFromcontinent { get; set; }
        public ICollection<Shippingmethodrate> ShippingmethodrateTocontinent { get; set; }
    }
}
