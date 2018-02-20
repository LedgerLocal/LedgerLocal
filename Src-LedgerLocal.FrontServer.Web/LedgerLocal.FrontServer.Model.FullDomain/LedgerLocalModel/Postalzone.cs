using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Postalzone
    {
        public Postalzone()
        {
            Postalzonecountrymap = new HashSet<Postalzonecountrymap>();
            ShippingmethodrateFrompostalzone = new HashSet<Shippingmethodrate>();
            ShippingmethodrateTopostalzone = new HashSet<Shippingmethodrate>();
        }

        public int Postalzoneid { get; set; }
        public string Zonename { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Postalzonecountrymap> Postalzonecountrymap { get; set; }
        public ICollection<Shippingmethodrate> ShippingmethodrateFrompostalzone { get; set; }
        public ICollection<Shippingmethodrate> ShippingmethodrateTopostalzone { get; set; }
    }
}
