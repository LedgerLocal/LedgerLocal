using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.FrontServer.Dto
{
    public class PageDto : GenericDto
    {

        public int Pageid { get; set; }
        public int? Categoryid { get; set; }
        public int? Pagetypeid { get; set; }
        public int? Parentpageid { get; set; }
        public string Title { get; set; }
        public bool Activate { get; set; }
        public bool Isdefault { get; set; }
        public string Url { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public int Sort { get; set; }

    }
}
