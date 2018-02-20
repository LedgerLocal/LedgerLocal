using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Mailinglistpeoplemap
    {
        public Mailinglistpeoplemap()
        {
            Mailinglistqueue = new HashSet<Mailinglistqueue>();
        }

        public int Mailinglistpeopleid { get; set; }
        public int? Peopleid { get; set; }
        public int? Mailinglistpeoplegroupid { get; set; }
        public bool? Activate { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Mailinglistpeoplegroup Mailinglistpeoplegroup { get; set; }
        public People People { get; set; }
        public ICollection<Mailinglistqueue> Mailinglistqueue { get; set; }
    }
}
