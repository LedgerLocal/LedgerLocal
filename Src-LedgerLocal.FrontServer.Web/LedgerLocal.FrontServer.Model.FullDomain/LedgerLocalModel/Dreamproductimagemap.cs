using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Dreamproductimagemap
    {
        public int Dreamproductimageid { get; set; }
        public int Productid { get; set; }
        public int Dreamimageid { get; set; }
        public bool? Activate { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Dreamimage Dreamimage { get; set; }
        public Dreamproduct Product { get; set; }
    }
}
