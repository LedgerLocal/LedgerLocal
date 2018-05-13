using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Attributeitem
    {
        public Attributeitem()
        {
            Attribute = new HashSet<Attribute>();
        }

        public int Attributeitemid { get; set; }
        public int? Attributetypeid { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public int Sort { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Attributetype Attributetype { get; set; }
        public ICollection<Attribute> Attribute { get; set; }
    }
}
