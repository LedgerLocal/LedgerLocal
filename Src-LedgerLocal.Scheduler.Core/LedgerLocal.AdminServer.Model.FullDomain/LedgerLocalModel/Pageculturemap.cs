using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Pageculturemap
    {
        public Pageculturemap()
        {
            Pageevent = new HashSet<Pageevent>();
        }

        public int Pageculturemapid { get; set; }
        public int? Pageid { get; set; }
        public int? Cultureid { get; set; }
        public string Title { get; set; }
        public string Metatitle { get; set; }
        public string Metakeyword { get; set; }
        public string Metadescription { get; set; }
        public string Keywords { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Culture Culture { get; set; }
        public Page Page { get; set; }
        public ICollection<Pageevent> Pageevent { get; set; }
    }
}
