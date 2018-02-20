using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Phone
    {
        public int Phoneid { get; set; }
        public int Phonetypeid { get; set; }
        public int Peopleid { get; set; }
        public string Phone1 { get; set; }
        public string Fax { get; set; }
        public string Cell { get; set; }
        public string Note { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public People People { get; set; }
        public Phonetype Phonetype { get; set; }
    }
}
