using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Queuestatus
    {
        public Queuestatus()
        {
            Accountmailqueue = new HashSet<Accountmailqueue>();
            Mailinglistqueue = new HashSet<Mailinglistqueue>();
            Ordermailqueue = new HashSet<Ordermailqueue>();
        }

        public int Queuestatusid { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Accountmailqueue> Accountmailqueue { get; set; }
        public ICollection<Mailinglistqueue> Mailinglistqueue { get; set; }
        public ICollection<Ordermailqueue> Ordermailqueue { get; set; }
    }
}
