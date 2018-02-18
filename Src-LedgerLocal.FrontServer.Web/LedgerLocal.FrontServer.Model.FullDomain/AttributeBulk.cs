using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.FrontServer.Model.FullDomain
{
    public class AttributeBulk
    {
        public string Type { get; set; }

        public string Value { get; set; }

        public object TypeObject { get; set; }

        public object ValueObject { get; set; }

        public int TypeSort { get; set; }

        public int ValueSort { get; set; }

        public int? CategoryId { get; set; }
    }
}
