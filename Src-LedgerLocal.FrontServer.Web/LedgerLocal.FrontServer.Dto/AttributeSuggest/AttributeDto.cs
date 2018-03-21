using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedgerLocal.FrontServer.Dto.AttributeSuggest
{
    public class AttributeDto
    {
        public AttributeTypeDto Type { get; set; }

        public AttributeItemDto Item { get; set; }

        public int Genericattributeid { get; set; }
        public int? Genericattributetypeid { get; set; }
        public int? Genericattributevalueid { get; set; }
        public string Typestring { get; set; }
        public string Typelabelstring { get; set; }
        public string Valuestring { get; set; }
        public string Valuelabelstring { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
    }
}
