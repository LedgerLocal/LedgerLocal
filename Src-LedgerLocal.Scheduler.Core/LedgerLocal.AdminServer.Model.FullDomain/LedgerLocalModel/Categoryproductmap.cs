using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Categoryproductmap
    {
        public int Categoryproductid { get; set; }
        public int Categoryid { get; set; }
        public int Productid { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Category Category { get; set; }
        public Product Product { get; set; }
    }
}
