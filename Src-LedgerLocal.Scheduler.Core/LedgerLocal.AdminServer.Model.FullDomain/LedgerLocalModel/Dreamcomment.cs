using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Dreamcomment
    {
        public int Commentid { get; set; }
        public int? Productid { get; set; }
        public int? Userid { get; set; }
        public int? Vote { get; set; }
        public char? Content { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Dreamproduct Product { get; set; }
        public User User { get; set; }
    }
}
