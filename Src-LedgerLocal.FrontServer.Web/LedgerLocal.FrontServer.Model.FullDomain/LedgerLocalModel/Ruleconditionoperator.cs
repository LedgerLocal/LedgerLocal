using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Ruleconditionoperator
    {
        public Ruleconditionoperator()
        {
            Cartrulecondition = new HashSet<Cartrulecondition>();
        }

        public int Ruleconditionoperatorid { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Cartrulecondition> Cartrulecondition { get; set; }
    }
}
