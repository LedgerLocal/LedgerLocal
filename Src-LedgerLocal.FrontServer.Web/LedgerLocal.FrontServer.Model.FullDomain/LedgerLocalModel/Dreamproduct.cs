using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Dreamproduct
    {
        public Dreamproduct()
        {
            Dreamcomment = new HashSet<Dreamcomment>();
            Dreamproductimagemap = new HashSet<Dreamproductimagemap>();
        }

        public int Productid { get; set; }
        public int? Userid { get; set; }
        public int? Vote { get; set; }
        public char? Content { get; set; }
        public int? Views { get; set; }
        public string Name { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public User User { get; set; }
        public ICollection<Dreamcomment> Dreamcomment { get; set; }
        public ICollection<Dreamproductimagemap> Dreamproductimagemap { get; set; }
    }
}
