using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Attributeevent
    {
        public int Attributeeventid { get; set; }
        public int Attributebehaviorid { get; set; }
        public int Attributeid { get; set; }
        public int? Userid { get; set; }
        public DateTime Eventdate { get; set; }
        public string Ip { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Attribute Attribute { get; set; }
        public Attributebehavior Attributebehavior { get; set; }
        public User User { get; set; }
    }
}
