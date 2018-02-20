using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Ordermailqueue
    {
        public int Ordermailqueueid { get; set; }
        public int Queuestatusid { get; set; }
        public int? Mailertemplateid { get; set; }
        public int? Orderid { get; set; }
        public bool Activate { get; set; }
        public string Message { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Mailertemplate Mailertemplate { get; set; }
        public Order Order { get; set; }
        public Queuestatus Queuestatus { get; set; }
    }
}
