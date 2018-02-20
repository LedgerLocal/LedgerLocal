using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Cartresultproductmap
    {
        public int Cartresultproductid { get; set; }
        public int? Cartruleresultid { get; set; }
        public int? Productid { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Cartruleresult Cartruleresult { get; set; }
        public Product Product { get; set; }
    }
}
