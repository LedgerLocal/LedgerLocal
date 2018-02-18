using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Model.FullDomain.Model
{
    public partial class CategoryCultureMap
    {
        public int CategoryCultureId { get; set; }
        public int CategoryId { get; set; }
        public int CultureId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryAlternativeName { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaTitle { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public virtual Category Category { get; set; }
        public virtual Culture Culture { get; set; }
    }
}
