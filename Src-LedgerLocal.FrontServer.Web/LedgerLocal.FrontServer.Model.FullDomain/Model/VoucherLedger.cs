using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Model.FullDomain.Model
{
    public partial class VoucherLedger
    {
        public VoucherLedger()
        {
            VoucherLedgerGenericAttributeMap = new HashSet<VoucherLedgerGenericAttributeMap>();
        }

        public long VoucherLedgerId { get; set; }
        public long? VoucherTypeId { get; set; }
        public int CoinId { get; set; }
        public int UserId { get; set; }
        public int GenericAttributeId { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string StringValue { get; set; }
        public bool Activate { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        

        public virtual ICollection<VoucherLedgerGenericAttributeMap> VoucherLedgerGenericAttributeMap { get; set; }
        public virtual GenericAttribute GenericAttribute { get; set; }
        public virtual User User { get; set; }
        public virtual VoucherType VoucherType { get; set; }
    }
}
