using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.AdminServer.Service
{
    public interface IGrapheneConfig
    {

        string GrapheneWs { get; set; }

        string GrapheneWallet1Ws { get; set; }

        string GrapheneWallet2Ws { get; set; }
        

    }
}
