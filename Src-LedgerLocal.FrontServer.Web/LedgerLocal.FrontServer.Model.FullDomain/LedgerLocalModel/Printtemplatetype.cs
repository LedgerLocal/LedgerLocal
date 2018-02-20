using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Printtemplatetype
    {
        public Printtemplatetype()
        {
            Printtemplate = new HashSet<Printtemplate>();
        }

        public int Printtypeid { get; set; }
        public string Description { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Printtemplate> Printtemplate { get; set; }
    }
}
