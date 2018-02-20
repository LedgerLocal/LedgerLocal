using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Mailinglistimagetype
    {
        public Mailinglistimagetype()
        {
            Mailinglistimagemap = new HashSet<Mailinglistimagemap>();
        }

        public int Mailinglistimagetypeid { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Mailinglistimagemap> Mailinglistimagemap { get; set; }
    }
}
