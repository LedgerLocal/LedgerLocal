using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Cartruleschedule
    {
        public Cartruleschedule()
        {
            Cartruleengine = new HashSet<Cartruleengine>();
        }

        public int Cartrulescheduleid { get; set; }
        public int? Branchid { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Cartruleengine> Cartruleengine { get; set; }
    }
}
