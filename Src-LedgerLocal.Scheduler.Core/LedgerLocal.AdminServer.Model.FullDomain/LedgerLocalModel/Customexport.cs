using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Customexport
    {
        public int Customexportid { get; set; }
        public int? Sourcetypeid { get; set; }
        public int? Defaultcsvdelimiter { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Csvdelimiter DefaultcsvdelimiterNavigation { get; set; }
        public Sourcetype Sourcetype { get; set; }
    }
}
