using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Model.FullDomain.Model
{
    public partial class WorkflowType
    {
        public WorkflowType()
        {
            WorkflowContainer = new HashSet<WorkflowContainer>();
        }

        public int WorkflowTypeId { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<WorkflowContainer> WorkflowContainer { get; set; }
        public virtual Category Category { get; set; }
    }
}
