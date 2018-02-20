using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Address
    {
        public Address()
        {
            OrderBillingaddress = new HashSet<Order>();
            OrderShippingaddress = new HashSet<Order>();
            Productwarehouse = new HashSet<Productwarehouse>();
        }

        public int Addressid { get; set; }
        public int? Postalcodeid { get; set; }
        public int Addresstypeid { get; set; }
        public int Peopleid { get; set; }
        public int? Businessid { get; set; }
        public int? Branchid { get; set; }
        public int? Brandid { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string Stateorprovince { get; set; }
        public string Postalcode { get; set; }
        public string Country { get; set; }
        public string Weburl { get; set; }
        public bool? Isdefault { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Addresstype Addresstype { get; set; }
        public People People { get; set; }
        public Postalcode PostalcodeNavigation { get; set; }
        public ICollection<Order> OrderBillingaddress { get; set; }
        public ICollection<Order> OrderShippingaddress { get; set; }
        public ICollection<Productwarehouse> Productwarehouse { get; set; }
    }
}
