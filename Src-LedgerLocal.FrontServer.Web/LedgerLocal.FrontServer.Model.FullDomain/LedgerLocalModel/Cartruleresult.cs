using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Cartruleresult
    {
        public Cartruleresult()
        {
            Cartresultproductmap = new HashSet<Cartresultproductmap>();
        }

        public int Cartruleresultid { get; set; }
        public int? Cartruleengineid { get; set; }
        public int? Ruleresultoperationid { get; set; }
        public string Resultvalue { get; set; }
        public string Name { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Cartruleengine Cartruleengine { get; set; }
        public Ruleresultoperation Ruleresultoperation { get; set; }
        public ICollection<Cartresultproductmap> Cartresultproductmap { get; set; }
    }
}
