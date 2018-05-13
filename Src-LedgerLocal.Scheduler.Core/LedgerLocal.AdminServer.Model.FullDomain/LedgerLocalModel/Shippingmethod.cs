using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Shippingmethod
    {
        public Shippingmethod()
        {
            Orderpackage = new HashSet<Orderpackage>();
            Ordershippingmethodmap = new HashSet<Ordershippingmethodmap>();
            Productshippingmethodmap = new HashSet<Productshippingmethodmap>();
            Shippingmethodrate = new HashSet<Shippingmethodrate>();
        }

        public int Shippingmethodid { get; set; }
        public int? Cultureid { get; set; }
        public string Carrier { get; set; }
        public string Servicename { get; set; }
        public string Description { get; set; }
        public decimal Rateperunit { get; set; }
        public decimal Baserate { get; set; }
        public string Estimateddelivery { get; set; }
        public int Daystodeliver { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Culture Culture { get; set; }
        public ICollection<Orderpackage> Orderpackage { get; set; }
        public ICollection<Ordershippingmethodmap> Ordershippingmethodmap { get; set; }
        public ICollection<Productshippingmethodmap> Productshippingmethodmap { get; set; }
        public ICollection<Shippingmethodrate> Shippingmethodrate { get; set; }
    }
}
