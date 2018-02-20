using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Printtemplate
    {
        public int Printtemplateid { get; set; }
        public int? Printtypeid { get; set; }
        public int? Cultureid { get; set; }
        public char Body { get; set; }
        public string Displayname { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Culture Culture { get; set; }
        public Printtemplatetype Printtype { get; set; }
    }
}
