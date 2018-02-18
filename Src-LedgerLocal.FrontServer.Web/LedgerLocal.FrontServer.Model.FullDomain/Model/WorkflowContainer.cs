using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Model.FullDomain.Model
{
    public partial class WorkflowContainer
    {
        public WorkflowContainer()
        {
            WorkflowGenericAttributeMap = new HashSet<WorkflowGenericAttributeMap>();
        }

        public int WorkflowContainerId { get; set; }
        public int WorkflowTypeId { get; set; }
        public int? CategoryId { get; set; }
        public int? PointOfSaleId { get; set; }
        public int? ProgramId { get; set; }
        public int CultureId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public bool IsComponent { get; set; }
        public bool IsEntryPoint { get; set; }
        public bool HasArguments { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<WorkflowGenericAttributeMap> WorkflowGenericAttributeMap { get; set; }
        public virtual Category Category { get; set; }
        public virtual WorkflowType WorkflowType { get; set; }
    }
}
