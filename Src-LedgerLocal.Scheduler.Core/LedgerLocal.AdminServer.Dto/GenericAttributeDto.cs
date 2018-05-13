using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.AdminServer.Dto
{
    public class GenericAttributeDto
    {
        public int Genericattributeid { get; set; }

        public string Typestring { get; set; }
        
        public string Valuestring { get; set; }

        public DateTime Createdon { get; set; }

        public DateTime Modifiedon { get; set; }

        public string Createdby { get; set; }

        public string Modifiedby { get; set; }
    }
}
