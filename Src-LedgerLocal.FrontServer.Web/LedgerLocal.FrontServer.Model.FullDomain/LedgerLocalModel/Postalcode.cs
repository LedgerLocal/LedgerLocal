using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Postalcode
    {
        public Postalcode()
        {
            Address = new HashSet<Address>();
            ShippingmethodrateFrompostalcode = new HashSet<Shippingmethodrate>();
            ShippingmethodrateTopostalcode = new HashSet<Shippingmethodrate>();
        }

        public int Postalcodeid { get; set; }
        public int? Countryid { get; set; }
        public int? Regionid { get; set; }
        public int? Cityid { get; set; }
        public string Postalnumber { get; set; }
        public string Postallabel { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public City City { get; set; }
        public Country Country { get; set; }
        public Region Region { get; set; }
        public ICollection<Address> Address { get; set; }
        public ICollection<Shippingmethodrate> ShippingmethodrateFrompostalcode { get; set; }
        public ICollection<Shippingmethodrate> ShippingmethodrateTopostalcode { get; set; }
    }
}
