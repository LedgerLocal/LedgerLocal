using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Mailinglistimagemap
    {
        public int Mailinglistimageid { get; set; }
        public int Mailinglistid { get; set; }
        public int Imageid { get; set; }
        public int? Mailinglistimagetypeid { get; set; }
        public int? Sort { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Image Image { get; set; }
        public Mailinglist Mailinglist { get; set; }
        public Mailinglistimagetype Mailinglistimagetype { get; set; }
    }
}
