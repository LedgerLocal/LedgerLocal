using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Mailinglistqueue
    {
        public int Mailinglistqueueid { get; set; }
        public int Queuestatusid { get; set; }
        public int? Mailertemplateid { get; set; }
        public int? Mailinglistpeopleid { get; set; }
        public int? Mailinglistid { get; set; }
        public bool Activate { get; set; }
        public string Message { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Mailertemplate Mailertemplate { get; set; }
        public Mailinglist Mailinglist { get; set; }
        public Mailinglistpeoplemap Mailinglistpeople { get; set; }
        public Queuestatus Queuestatus { get; set; }
    }
}
