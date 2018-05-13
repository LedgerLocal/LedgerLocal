using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Category
    {
        public Category()
        {
            Categoryculturemap = new HashSet<Categoryculturemap>();
            Categoryimagemap = new HashSet<Categoryimagemap>();
            Categoryproductmap = new HashSet<Categoryproductmap>();
            Genericattributetype = new HashSet<Genericattributetype>();
            InverseParent = new HashSet<Category>();
            Page = new HashSet<Page>();
            Salecategorymap = new HashSet<Salecategorymap>();
            Workflowcontainer = new HashSet<Workflowcontainer>();
            Workflowtype = new HashSet<Workflowtype>();
        }

        public int Categoryid { get; set; }
        public int? Parentid { get; set; }
        public bool? Isdefault { get; set; }
        public bool Activate { get; set; }
        public int Sort { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Category Parent { get; set; }
        public ICollection<Categoryculturemap> Categoryculturemap { get; set; }
        public ICollection<Categoryimagemap> Categoryimagemap { get; set; }
        public ICollection<Categoryproductmap> Categoryproductmap { get; set; }
        public ICollection<Genericattributetype> Genericattributetype { get; set; }
        public ICollection<Category> InverseParent { get; set; }
        public ICollection<Page> Page { get; set; }
        public ICollection<Salecategorymap> Salecategorymap { get; set; }
        public ICollection<Workflowcontainer> Workflowcontainer { get; set; }
        public ICollection<Workflowtype> Workflowtype { get; set; }
    }
}
