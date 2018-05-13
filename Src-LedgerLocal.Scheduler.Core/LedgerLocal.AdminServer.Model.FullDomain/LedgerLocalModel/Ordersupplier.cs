using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Ordersupplier
    {
        public Ordersupplier()
        {
            Orderitemsuppliermap = new HashSet<Orderitemsuppliermap>();
        }

        public int Ordersupplierid { get; set; }
        public int Productwarehouseid { get; set; }
        public int? Supplierid { get; set; }
        public int? Ordersupplierstatusid { get; set; }
        public int? Userid { get; set; }
        public string Ordernumber { get; set; }
        public string Trackingnumber { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Shippingamount { get; set; }
        public decimal Taxamount { get; set; }
        public decimal Grandtotal { get; set; }
        public DateTime? Estimateddelivery { get; set; }
        public bool Validate { get; set; }
        public string Note { get; set; }
        public DateTime? Executedon { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Ordersupplierstatus Ordersupplierstatus { get; set; }
        public Productwarehouse Productwarehouse { get; set; }
        public Supplier Supplier { get; set; }
        public User User { get; set; }
        public ICollection<Orderitemsuppliermap> Orderitemsuppliermap { get; set; }
    }
}
