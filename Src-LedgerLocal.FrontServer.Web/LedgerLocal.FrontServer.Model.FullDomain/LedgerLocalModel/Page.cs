using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Page
    {
        public Page()
        {
            Contentblock = new HashSet<Contentblock>();
            Instantnotificationpagemap = new HashSet<Instantnotificationpagemap>();
            InverseParentpage = new HashSet<Page>();
            Pageculturemap = new HashSet<Pageculturemap>();
            Pageimagemap = new HashSet<Pageimagemap>();
        }

        public int Pageid { get; set; }
        public int? Categoryid { get; set; }
        public int? Pagetypeid { get; set; }
        public int? Parentpageid { get; set; }
        public string Title { get; set; }
        public bool Activate { get; set; }
        public bool Isdefault { get; set; }
        public string Url { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public int Sort { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Category Category { get; set; }
        public Pagetype Pagetype { get; set; }
        public Page Parentpage { get; set; }
        public ICollection<Contentblock> Contentblock { get; set; }
        public ICollection<Instantnotificationpagemap> Instantnotificationpagemap { get; set; }
        public ICollection<Page> InverseParentpage { get; set; }
        public ICollection<Pageculturemap> Pageculturemap { get; set; }
        public ICollection<Pageimagemap> Pageimagemap { get; set; }
    }
}
