using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Mailinglistpeoplegroup
    {
        public Mailinglistpeoplegroup()
        {
            Mailinglist = new HashSet<Mailinglist>();
            Mailinglistpeoplemap = new HashSet<Mailinglistpeoplemap>();
        }

        public int Mailinglistpeoplegroupid { get; set; }
        public string Name { get; set; }
        public bool Private { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Mailinglist> Mailinglist { get; set; }
        public ICollection<Mailinglistpeoplemap> Mailinglistpeoplemap { get; set; }
    }
}
