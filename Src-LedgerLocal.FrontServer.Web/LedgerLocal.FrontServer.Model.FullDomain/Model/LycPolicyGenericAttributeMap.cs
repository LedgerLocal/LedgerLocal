using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Model.FullDomain.Model
{
    public partial class LedgerLocalPolicyGenericAttributeMap
    {
        public int LedgerLocalPolicyGenericAttributeId { get; set; }
        public int GenericAttributeId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public virtual GenericAttribute GenericAttribute { get; set; }
    }
}
