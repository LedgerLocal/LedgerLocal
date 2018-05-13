using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Stockmanagmenttype
    {
        public Stockmanagmenttype()
        {
            Stockmanagment = new HashSet<Stockmanagment>();
        }

        public int Stockmanagmenttypeid { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Stockmanagment> Stockmanagment { get; set; }
    }
}
