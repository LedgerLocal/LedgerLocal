using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Productevent
    {
        public int Producteventid { get; set; }
        public int Productbehaviorid { get; set; }
        public int Productcultureid { get; set; }
        public int? Userid { get; set; }
        public DateTime Eventdate { get; set; }
        public string Ip { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Productbehavior Productbehavior { get; set; }
        public Productculturemap Productculture { get; set; }
        public User User { get; set; }
    }
}
