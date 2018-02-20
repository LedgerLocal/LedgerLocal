using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Transactionprocessor
    {
        public Transactionprocessor()
        {
            Transaction = new HashSet<Transaction>();
        }

        public int Processorid { get; set; }
        public string Description { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Transaction> Transaction { get; set; }
    }
}
