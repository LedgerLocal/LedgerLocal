using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Productreview
    {
        public Productreview()
        {
            Abuseproductreviewmap = new HashSet<Abuseproductreviewmap>();
        }

        public int Productreviewid { get; set; }
        public int Productid { get; set; }
        public DateTime Reviewdate { get; set; }
        public string Body { get; set; }
        public bool Approved { get; set; }
        public int Cultureid { get; set; }
        public int? Userid { get; set; }
        public int Rating { get; set; }
        public bool? Usefull { get; set; }
        public int? Abusecount { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Culture Culture { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
        public ICollection<Abuseproductreviewmap> Abuseproductreviewmap { get; set; }
    }
}
