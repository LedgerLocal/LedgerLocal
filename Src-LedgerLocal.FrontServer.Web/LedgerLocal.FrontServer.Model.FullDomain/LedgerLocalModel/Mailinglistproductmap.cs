using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Mailinglistproductmap
    {
        public int Mailinglistproductid { get; set; }
        public int Mailinglistid { get; set; }
        public int Productid { get; set; }
        public int? Sort { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Mailinglist Mailinglist { get; set; }
        public Product Product { get; set; }
    }
}
