using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.AdminServer.Service
{
    public class GrapheneConfig : IGrapheneConfig
    {
        public GrapheneConfig()
        {
        }

        public GrapheneConfig(string blockWs, string walletWs)
        {
            GrapheneWalletWs = walletWs;
            GrapheneBlockchainWs = blockWs;
        }

        public string GrapheneWalletWs { get; set; }
        public string GrapheneBlockchainWs { get; set; }
    }
}
