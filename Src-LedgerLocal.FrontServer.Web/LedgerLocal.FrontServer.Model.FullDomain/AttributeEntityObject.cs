using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.FrontServer.Model.FullDomain
{
    public class AttributeEntityObject
    {
        public string Type { get; set; }

        public string Value { get; set; }

        public object TypeObject { get; set; }

        public object ValueObject { get; set; }

        public int TypeSort { get; set; }

        public int ValueSort { get; set; }

        public int? CategoryId { get; set; }

        public string TypeMetaTypeString { get; set; }

        public string TypeMetaTypeFullString { get; set; }

        public string ValueMetaTypeString { get; set; }

        public string ValueMetaTypeFullString { get; set; }
    }
}
