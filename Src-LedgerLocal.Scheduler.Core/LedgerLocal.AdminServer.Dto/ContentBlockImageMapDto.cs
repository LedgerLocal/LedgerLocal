using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.AdminServer.Dto
{
    public class ContentBlockImageMapDto : GenericDto
    {

        public int Contentblockimagemapid { get; set; }
        public int? Contentblockid { get; set; }
        public int? Imageid { get; set; }
        public bool Activate { get; set; }

    }
}
