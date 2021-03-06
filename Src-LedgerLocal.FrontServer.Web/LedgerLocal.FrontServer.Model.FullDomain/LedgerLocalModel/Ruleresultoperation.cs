﻿using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Ruleresultoperation
    {
        public Ruleresultoperation()
        {
            Cartruleresult = new HashSet<Cartruleresult>();
        }

        public int Ruleresultoperationid { get; set; }
        public string Operation { get; set; }
        public string Description { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Cartruleresult> Cartruleresult { get; set; }
    }
}
