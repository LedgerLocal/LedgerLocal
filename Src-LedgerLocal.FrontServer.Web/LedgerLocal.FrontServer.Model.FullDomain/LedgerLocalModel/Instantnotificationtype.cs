using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Instantnotificationtype
    {
        public Instantnotificationtype()
        {
            Instantnotification = new HashSet<Instantnotification>();
        }

        public int Instantnotificationtypeid { get; set; }
        public string Notificationtype { get; set; }
        public string Description { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Instantnotification> Instantnotification { get; set; }
    }
}
