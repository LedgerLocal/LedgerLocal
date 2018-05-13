using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Cartruleengine
    {
        public Cartruleengine()
        {
            Cartrulecondition = new HashSet<Cartrulecondition>();
            Cartruleresult = new HashSet<Cartruleresult>();
            Cartruleshoppingcartmap = new HashSet<Cartruleshoppingcartmap>();
        }

        public int Cartruleengineid { get; set; }
        public int? Cartrulescheduleid { get; set; }
        public string Name { get; set; }
        public bool Activate { get; set; }
        public string Description { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Cartruleschedule Cartruleschedule { get; set; }
        public ICollection<Cartrulecondition> Cartrulecondition { get; set; }
        public ICollection<Cartruleresult> Cartruleresult { get; set; }
        public ICollection<Cartruleshoppingcartmap> Cartruleshoppingcartmap { get; set; }
    }
}
