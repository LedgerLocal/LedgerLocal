using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Supplier
    {
        public Supplier()
        {
            Contact = new HashSet<Contact>();
            Ordersupplier = new HashSet<Ordersupplier>();
            Productsuppliermap = new HashSet<Productsuppliermap>();
            Supplierculturemap = new HashSet<Supplierculturemap>();
            Supplierimagemap = new HashSet<Supplierimagemap>();
            Suppliernote = new HashSet<Suppliernote>();
        }

        public int Supplierid { get; set; }
        public int? Suppliertypeid { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Skuprefix { get; set; }
        public string Email { get; set; }
        public string Weburl { get; set; }
        public bool? Dealingwith { get; set; }
        public bool? Dealedwith { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Suppliertype Suppliertype { get; set; }
        public ICollection<Contact> Contact { get; set; }
        public ICollection<Ordersupplier> Ordersupplier { get; set; }
        public ICollection<Productsuppliermap> Productsuppliermap { get; set; }
        public ICollection<Supplierculturemap> Supplierculturemap { get; set; }
        public ICollection<Supplierimagemap> Supplierimagemap { get; set; }
        public ICollection<Suppliernote> Suppliernote { get; set; }
    }
}
