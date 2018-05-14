using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.AdminServer.Service
{
    public interface IGrapheneConfig
    {

        string GrapheneWalletWs { get; set; }

        string GrapheneBlockchainWs { get; set; }

    }
}
