using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Instantnotification
    {
        public Instantnotification()
        {
            Instantnotificationpagemap = new HashSet<Instantnotificationpagemap>();
        }

        public int Instantnotificationid { get; set; }
        public int? Instantnotificationtypeid { get; set; }
        public string Notification { get; set; }
        public bool Ishtml { get; set; }
        public bool? Sticky { get; set; }
        public int? Delay { get; set; }
        public int? Sort { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Instantnotificationtype Instantnotificationtype { get; set; }
        public ICollection<Instantnotificationpagemap> Instantnotificationpagemap { get; set; }
    }
}
