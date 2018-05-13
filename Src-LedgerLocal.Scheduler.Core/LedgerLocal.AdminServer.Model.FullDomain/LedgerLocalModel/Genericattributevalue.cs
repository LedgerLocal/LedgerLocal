using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Genericattributevalue
    {
        public Genericattributevalue()
        {
            Genericattribute = new HashSet<Genericattribute>();
        }

        public int Genericattributevalueid { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public int Sort { get; set; }
        public string Metatypestring { get; set; }
        public string Metatypelabel { get; set; }
        public string Valuestring { get; set; }
        public decimal? Valuenumber { get; set; }
        public bool? Valuebool { get; set; }
        public DateTime? Valuedate { get; set; }
        public string Valuelabelstring { get; set; }
        public decimal? Valuelabelnumber { get; set; }
        public bool? Valuelabelbool { get; set; }
        public DateTime? Valuelabeldate { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Genericattribute> Genericattribute { get; set; }
    }
}
