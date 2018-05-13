using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Attributetype
    {
        public Attributetype()
        {
            Attribute = new HashSet<Attribute>();
            Attributeitem = new HashSet<Attributeitem>();
        }

        public int Attributetypeid { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Attribute> Attribute { get; set; }
        public ICollection<Attributeitem> Attributeitem { get; set; }
    }
}
