using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class City
    {
        public City()
        {
            Postalcode = new HashSet<Postalcode>();
            Taxrate = new HashSet<Taxrate>();
        }

        public int Cityid { get; set; }
        public int? Countryid { get; set; }
        public int? Regionid { get; set; }
        public string City1 { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string Timezone { get; set; }
        public string Dmaid { get; set; }
        public string Citycode { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Country Country { get; set; }
        public Region Region { get; set; }
        public ICollection<Postalcode> Postalcode { get; set; }
        public ICollection<Taxrate> Taxrate { get; set; }
    }
}
