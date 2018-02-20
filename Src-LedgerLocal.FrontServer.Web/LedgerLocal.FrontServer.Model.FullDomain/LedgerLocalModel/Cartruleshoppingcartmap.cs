using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Cartruleshoppingcartmap
    {
        public int Cartruleshoppingcartid { get; set; }
        public int? Cartruleengineid { get; set; }
        public int? Shoppingcartid { get; set; }
        public bool? Applied { get; set; }
        public string Promotioncode { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Cartruleengine Cartruleengine { get; set; }
        public Shoppingcart Shoppingcart { get; set; }
    }
}
