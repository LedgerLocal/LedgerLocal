using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Categoryculturemap
    {
        public int Categorycultureid { get; set; }
        public int Categoryid { get; set; }
        public int Cultureid { get; set; }
        public string Categoryname { get; set; }
        public string Categoryalternativename { get; set; }
        public string Metadescription { get; set; }
        public string Metakeyword { get; set; }
        public string Metatitle { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Category Category { get; set; }
        public Culture Culture { get; set; }
    }
}
