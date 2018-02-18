using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Model.FullDomain.Model
{
    public partial class GenericAttribute
    {
        public GenericAttribute()
        {
            LedgerLocalPolicyGenericAttributeMap = new HashSet<LedgerLocalPolicyGenericAttributeMap>();
            VoucherLedger = new HashSet<VoucherLedger>();
            VoucherLedgerGenericAttributeMap = new HashSet<VoucherLedgerGenericAttributeMap>();
            WorkflowGenericAttributeMap = new HashSet<WorkflowGenericAttributeMap>();
        }

        public int GenericAttributeId { get; set; }
        public int? GenericAttributeTypeId { get; set; }
        public int? GenericAttributeValueId { get; set; }
        public string TypeString { get; set; }
        public string TypeLabelString { get; set; }
        public string ValueString { get; set; }
        public string ValueLabelString { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<LedgerLocalPolicyGenericAttributeMap> LedgerLocalPolicyGenericAttributeMap { get; set; }
        public virtual ICollection<VoucherLedger> VoucherLedger { get; set; }
        public virtual ICollection<VoucherLedgerGenericAttributeMap> VoucherLedgerGenericAttributeMap { get; set; }
        public virtual ICollection<WorkflowGenericAttributeMap> WorkflowGenericAttributeMap { get; set; }
        public virtual GenericAttributeType GenericAttributeType { get; set; }
        public virtual GenericAttributeValue GenericAttributeValue { get; set; }
    }
}
