using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.AdminServer.Dto
{
    public class ArticleDto : GenericDto
    {
        public int Articleid { get; set; }
        public int Cultureid { get; set; }
        public int Userid { get; set; }
        public string Title { get; set; }
        public string Metatitle { get; set; }
        public string Metakeyword { get; set; }
        public string Metadescription { get; set; }
        public string Keywords { get; set; }
        public string Body { get; set; }
        public bool? Ishtml { get; set; }
        public bool Activate { get; set; }

        public string Imagethumb { get; set; }
        public string Imagepost { get; set; }
    }
}
