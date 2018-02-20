using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Genericattributevalue
    {
        public Genericattributevalue()
        {
            Genericattribute = new HashSet<Genericattribute>();
        }

        public int Genericattributevalueid { get; set; }
        public char Name { get; set; }
        public char? Label { get; set; }
        public int Sort { get; set; }
        public char? Metatypestring { get; set; }
        public char? Metatypelabel { get; set; }
        public char? Valuestring { get; set; }
        public decimal? Valuenumber { get; set; }
        public bool? Valuebool { get; set; }
        public DateTime? Valuedate { get; set; }
        public char? Valuelabelstring { get; set; }
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
