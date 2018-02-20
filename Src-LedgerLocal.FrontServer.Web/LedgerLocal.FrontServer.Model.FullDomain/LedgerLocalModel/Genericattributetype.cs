using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Genericattributetype
    {
        public Genericattributetype()
        {
            Genericattribute = new HashSet<Genericattribute>();
        }

        public int Genericattributetypeid { get; set; }
        public int? Categoryid { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }
        public string Metatypestring { get; set; }
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

        public Category Category { get; set; }
        public ICollection<Genericattribute> Genericattribute { get; set; }
    }
}
