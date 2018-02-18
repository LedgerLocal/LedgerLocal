using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Model.FullDomain.Model
{
    public partial class VoucherLedgerGenericAttributeMap
    {
        public int VoucherLedgerGenericAttributeId { get; set; }
        public long? VoucherLedgerId { get; set; }
        public int? GenericAttributeId { get; set; }
        public bool? Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public virtual GenericAttribute GenericAttribute { get; set; }
        public virtual VoucherLedger VoucherLedger { get; set; }
    }
}
