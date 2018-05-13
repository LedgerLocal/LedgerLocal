using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Product
    {
        public Product()
        {
            Cartresultproductmap = new HashSet<Cartresultproductmap>();
            Categoryproductmap = new HashSet<Categoryproductmap>();
            Mailinglistproductmap = new HashSet<Mailinglistproductmap>();
            Orderitem = new HashSet<Orderitem>();
            Orderitemsuppliermap = new HashSet<Orderitemsuppliermap>();
            Productattributemap = new HashSet<Productattributemap>();
            ProductcrosssellmapCrossproduct = new HashSet<Productcrosssellmap>();
            ProductcrosssellmapProduct = new HashSet<Productcrosssellmap>();
            Productculturemap = new HashSet<Productculturemap>();
            Productimagemap = new HashSet<Productimagemap>();
            ProductrelatedmapProduct = new HashSet<Productrelatedmap>();
            ProductrelatedmapRelatedproduct = new HashSet<Productrelatedmap>();
            Productreview = new HashSet<Productreview>();
            Productshippingmethodmap = new HashSet<Productshippingmethodmap>();
            Productsuppliermap = new HashSet<Productsuppliermap>();
            Saleproductmap = new HashSet<Saleproductmap>();
            Shoppingcartevent = new HashSet<Shoppingcartevent>();
            Shoppingcartproductmap = new HashSet<Shoppingcartproductmap>();
            Subproductattributemap = new HashSet<Subproductattributemap>();
            SubproductmapProduct = new HashSet<Subproductmap>();
            SubproductmapSubproduct = new HashSet<Subproductmap>();
        }

        public int Productid { get; set; }
        public string Productcode { get; set; }
        public string Productsku { get; set; }
        public string Productean { get; set; }
        public int Deliverymethodid { get; set; }
        public int? Productgroupid { get; set; }
        public int? Stockmanagmentid { get; set; }
        public string Productname { get; set; }
        public decimal? Supplierprice { get; set; }
        public string Suppliersku { get; set; }
        public int Supplierminimumqty { get; set; }
        public string Supplierinfo { get; set; }
        public bool? Trackinventory { get; set; }
        public bool Activate { get; set; }
        public int? Sort { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Deliverymethod Deliverymethod { get; set; }
        public Productgroup Productgroup { get; set; }
        public Stockmanagment Stockmanagment { get; set; }
        public ICollection<Cartresultproductmap> Cartresultproductmap { get; set; }
        public ICollection<Categoryproductmap> Categoryproductmap { get; set; }
        public ICollection<Mailinglistproductmap> Mailinglistproductmap { get; set; }
        public ICollection<Orderitem> Orderitem { get; set; }
        public ICollection<Orderitemsuppliermap> Orderitemsuppliermap { get; set; }
        public ICollection<Productattributemap> Productattributemap { get; set; }
        public ICollection<Productcrosssellmap> ProductcrosssellmapCrossproduct { get; set; }
        public ICollection<Productcrosssellmap> ProductcrosssellmapProduct { get; set; }
        public ICollection<Productculturemap> Productculturemap { get; set; }
        public ICollection<Productimagemap> Productimagemap { get; set; }
        public ICollection<Productrelatedmap> ProductrelatedmapProduct { get; set; }
        public ICollection<Productrelatedmap> ProductrelatedmapRelatedproduct { get; set; }
        public ICollection<Productreview> Productreview { get; set; }
        public ICollection<Productshippingmethodmap> Productshippingmethodmap { get; set; }
        public ICollection<Productsuppliermap> Productsuppliermap { get; set; }
        public ICollection<Saleproductmap> Saleproductmap { get; set; }
        public ICollection<Shoppingcartevent> Shoppingcartevent { get; set; }
        public ICollection<Shoppingcartproductmap> Shoppingcartproductmap { get; set; }
        public ICollection<Subproductattributemap> Subproductattributemap { get; set; }
        public ICollection<Subproductmap> SubproductmapProduct { get; set; }
        public ICollection<Subproductmap> SubproductmapSubproduct { get; set; }
    }
}
