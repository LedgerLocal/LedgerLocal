﻿using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Subproductmap
    {
        public int Subproductmapid { get; set; }
        public int? Productid { get; set; }
        public int? Subproductid { get; set; }
        public bool? Activate { get; set; }
        public int? Sort { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Product Product { get; set; }
        public Product Subproduct { get; set; }
    }
}
