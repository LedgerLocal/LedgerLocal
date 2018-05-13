using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Phonetype
    {
        public Phonetype()
        {
            Phone = new HashSet<Phone>();
        }

        public int Phonetypeid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Phone> Phone { get; set; }
    }
}
