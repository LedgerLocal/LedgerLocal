using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.FrontServer.Dto
{
    public class GenericDto
    {

        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

    }
}
