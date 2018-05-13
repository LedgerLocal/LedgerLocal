using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.AdminServer.Service
{
    public interface IGlobalConfig
    {

        string SeqServer { get; set; }

        string EsUrl { get; set; }

    }
}
