using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Model.FullDomain.Model
{
    public partial class VoucherType
    {
        public VoucherType()
        {
            VoucherLedger = new HashSet<VoucherLedger>();
        }

        public long VoucherTypeId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<VoucherLedger> VoucherLedger { get; set; }
    }
}
