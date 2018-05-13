using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.AdminServer.Service
{
    public class GlobalConfig : IGlobalConfig
    {

        public string SeqServer { get; set; }

        public string EsUrl { get; set; }

    }
}
