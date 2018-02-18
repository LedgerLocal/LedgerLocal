using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Model.FullDomain.Model
{
    public partial class GenericAttributeValue
    {
        public GenericAttributeValue()
        {
            GenericAttribute = new HashSet<GenericAttribute>();
        }

        public int GenericAttributeValueId { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public int Sort { get; set; }
        public string MetaTypeString { get; set; }
        public string MetaTypeLabel { get; set; }
        public string ValueString { get; set; }
        public decimal? ValueNumber { get; set; }
        public bool? ValueBool { get; set; }
        public DateTime? ValueDate { get; set; }
        public string ValueLabelString { get; set; }
        public decimal? ValueLabelNumber { get; set; }
        public bool? ValueLabelBool { get; set; }
        public DateTime? ValueLabelDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<GenericAttribute> GenericAttribute { get; set; }
    }
}
