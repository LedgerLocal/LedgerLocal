using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Order
    {
        public Order()
        {
            Ordercouponmap = new HashSet<Ordercouponmap>();
            Orderitem = new HashSet<Orderitem>();
            Ordermailqueue = new HashSet<Ordermailqueue>();
            Ordernote = new HashSet<Ordernote>();
            Orderpackage = new HashSet<Orderpackage>();
            Ordershippingmethodmap = new HashSet<Ordershippingmethodmap>();
            Productcrosssellmap = new HashSet<Productcrosssellmap>();
            Returnmaterial = new HashSet<Returnmaterial>();
            Transaction = new HashSet<Transaction>();
        }

        public int Orderid { get; set; }
        public int Orderstatusid { get; set; }
        public int? Billingaddressid { get; set; }
        public int? Shippingaddressid { get; set; }
        public int? Userid { get; set; }
        public int? Cultureid { get; set; }
        public int? Coinid { get; set; }
        public string Ordernumber { get; set; }
        public decimal Subtotal { get; set; }
        public decimal? Subshippingtotal { get; set; }
        public decimal? Shippingamount { get; set; }
        public decimal? Subweeetotal { get; set; }
        public decimal? Weeeamount { get; set; }
        public decimal Taxamount { get; set; }
        public decimal Grandtotal { get; set; }
        public decimal? Couponamount { get; set; }
        public decimal Finaltotal { get; set; }
        public DateTime? Dateshipped { get; set; }
        public string Trackingnumber { get; set; }
        public DateTime? Estimateddelivery { get; set; }
        public DateTime? Executedon { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Address Billingaddress { get; set; }
        public Culture Culture { get; set; }
        public Orderstatus Orderstatus { get; set; }
        public Address Shippingaddress { get; set; }
        public User User { get; set; }
        public ICollection<Ordercouponmap> Ordercouponmap { get; set; }
        public ICollection<Orderitem> Orderitem { get; set; }
        public ICollection<Ordermailqueue> Ordermailqueue { get; set; }
        public ICollection<Ordernote> Ordernote { get; set; }
        public ICollection<Orderpackage> Orderpackage { get; set; }
        public ICollection<Ordershippingmethodmap> Ordershippingmethodmap { get; set; }
        public ICollection<Productcrosssellmap> Productcrosssellmap { get; set; }
        public ICollection<Returnmaterial> Returnmaterial { get; set; }
        public ICollection<Transaction> Transaction { get; set; }
    }
}
