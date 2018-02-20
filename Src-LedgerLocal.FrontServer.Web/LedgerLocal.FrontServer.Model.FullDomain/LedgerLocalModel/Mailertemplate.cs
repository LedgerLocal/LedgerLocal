using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Mailertemplate
    {
        public Mailertemplate()
        {
            Accountmailqueue = new HashSet<Accountmailqueue>();
            Mailinglist = new HashSet<Mailinglist>();
            Mailinglistqueue = new HashSet<Mailinglistqueue>();
            Ordermailqueue = new HashSet<Ordermailqueue>();
        }

        public int Mailertemplateid { get; set; }
        public int Mailertypeid { get; set; }
        public int Cultureid { get; set; }
        public string Subject { get; set; }
        public char Body { get; set; }
        public bool? Ishtml { get; set; }
        public bool? Isdefault { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Culture Culture { get; set; }
        public Mailertemplatetype Mailertype { get; set; }
        public ICollection<Accountmailqueue> Accountmailqueue { get; set; }
        public ICollection<Mailinglist> Mailinglist { get; set; }
        public ICollection<Mailinglistqueue> Mailinglistqueue { get; set; }
        public ICollection<Ordermailqueue> Ordermailqueue { get; set; }
    }
}
