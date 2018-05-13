using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Cartrulecondition
    {
        public int Cartruleconditionid { get; set; }
        public int? Cartruleengineid { get; set; }
        public int Ruleconditionoperatorid { get; set; }
        public string Conditionmember { get; set; }
        public string Conditionvalue { get; set; }
        public string Name { get; set; }
        public bool? Activate { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Cartruleengine Cartruleengine { get; set; }
        public Ruleconditionoperator Ruleconditionoperator { get; set; }
    }
}
