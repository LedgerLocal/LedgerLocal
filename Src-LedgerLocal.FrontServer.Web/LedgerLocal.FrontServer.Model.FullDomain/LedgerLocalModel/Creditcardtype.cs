﻿using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Creditcardtype
    {
        public Creditcardtype()
        {
            Transaction = new HashSet<Transaction>();
        }

        public int Creditcardtypeid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Transaction> Transaction { get; set; }
    }
}
