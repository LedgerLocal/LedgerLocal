using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.AdminServer.Dto
{
    public class CultureDto : GenericDto
    {

        public int Cultureid { get; set; }
        public string Languagecode { get; set; }
        public string Locale { get; set; }
        public string Defaultcurrencycode { get; set; }
        public string Defaultsizecode { get; set; }
        public string Defaultweightcode { get; set; }
        public string Defaultsizeunit { get; set; }
        public string Defaultweightunit { get; set; }

    }
}
