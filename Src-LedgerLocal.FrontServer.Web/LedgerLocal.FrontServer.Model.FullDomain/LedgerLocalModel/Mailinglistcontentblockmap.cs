using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Mailinglistcontentblockmap
    {
        public int Mailinglistcontentblockid { get; set; }
        public int Mailinglistid { get; set; }
        public int Contentblockid { get; set; }
        public int? Mailinglistcontentblocktypeid { get; set; }
        public int? Sort { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Contentblock Contentblock { get; set; }
        public Mailinglist Mailinglist { get; set; }
        public Mailinglistcontentblocktype Mailinglistcontentblocktype { get; set; }
    }
}
