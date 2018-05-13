using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Abuseproductreviewmap
    {
        public int Abuseproductreviewid { get; set; }
        public int Productreviewid { get; set; }
        public int Peopleid { get; set; }
        public bool Isabuse { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public User People { get; set; }
        public Productreview Productreview { get; set; }
    }
}
