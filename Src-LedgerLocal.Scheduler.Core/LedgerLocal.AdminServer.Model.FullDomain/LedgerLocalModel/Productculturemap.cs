using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Productculturemap
    {
        public Productculturemap()
        {
            Productevent = new HashSet<Productevent>();
        }

        public int Productcultureid { get; set; }
        public int Productid { get; set; }
        public int Cultureid { get; set; }
        public int? Taxweeeid { get; set; }
        public string Description { get; set; }
        public string Shortdescription { get; set; }
        public int? Warranty { get; set; }
        public decimal Baseunitprice { get; set; }
        public decimal? Discountpercent { get; set; }
        public decimal? Extrashipfee { get; set; }
        public string Productname { get; set; }
        public string Metatitle { get; set; }
        public string Metakeyword { get; set; }
        public string Metadescription { get; set; }
        public string Keywords { get; set; }
        public bool Allowreturn { get; set; }
        public bool? Allowbackorder { get; set; }
        public bool? Shipseparately { get; set; }
        public int? Minimumqty { get; set; }
        public int? Estimatedhandlingtime { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }
        public decimal Weight { get; set; }
        public bool Activate { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Culture Culture { get; set; }
        public Product Product { get; set; }
        public Taxweee Taxweee { get; set; }
        public ICollection<Productevent> Productevent { get; set; }
    }
}
