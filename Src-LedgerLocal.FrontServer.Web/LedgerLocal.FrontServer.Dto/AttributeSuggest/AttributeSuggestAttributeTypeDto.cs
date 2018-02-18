using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedgerLocal.FrontServer.Dto.AttributeSuggest
{
    public class AttributeSuggestAttributeTypeDto
    {
        public int AttributeTypeID { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public Nullable<bool> Active { get; set; }
        public string ItemUnitLabel { get; set; }
        public Nullable<int> ItemPrimitiveType { get; set; }
    }
}
