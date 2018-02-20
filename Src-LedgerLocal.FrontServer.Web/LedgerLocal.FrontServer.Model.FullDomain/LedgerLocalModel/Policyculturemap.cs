using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Policyculturemap
    {
        public int Policyculturemapid { get; set; }
        public int? Cultureid { get; set; }
        public int? Policyid { get; set; }
        public char Content { get; set; }
        public bool Activate { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Culture Culture { get; set; }
        public Policy Policy { get; set; }
    }
}
