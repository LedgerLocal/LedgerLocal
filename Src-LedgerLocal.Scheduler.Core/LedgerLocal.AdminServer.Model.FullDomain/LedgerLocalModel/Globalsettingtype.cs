using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Globalsettingtype
    {
        public Globalsettingtype()
        {
            Globalsetting = new HashSet<Globalsetting>();
        }

        public int Globalsettingtypeid { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Globalsetting> Globalsetting { get; set; }
    }
}
