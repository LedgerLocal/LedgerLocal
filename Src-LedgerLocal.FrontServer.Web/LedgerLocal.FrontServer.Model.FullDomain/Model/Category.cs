using LedgerLocal.FrontServer.Model.FullDomain.Model;
using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Model.FullDomain.Model
{
    public partial class Category
    {
        public Category()
        {
            CategoryCultureMap = new HashSet<CategoryCultureMap>();
            GenericAttributeType = new HashSet<GenericAttributeType>();
            WorkflowContainer = new HashSet<WorkflowContainer>();
            WorkflowType = new HashSet<WorkflowType>();
        }

        public int CategoryId { get; set; }
        public int? ParentId { get; set; }
        public bool IsDefault { get; set; }
        public bool Activate { get; set; }
        public int Sort { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<CategoryCultureMap> CategoryCultureMap { get; set; }
        public virtual ICollection<GenericAttributeType> GenericAttributeType { get; set; }
        public virtual ICollection<WorkflowContainer> WorkflowContainer { get; set; }
        public virtual ICollection<WorkflowType> WorkflowType { get; set; }
        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> InverseParent { get; set; }
    }
}
