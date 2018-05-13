using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.AdminServer.Service
{
    public class GrapheneConfig : IGrapheneConfig
    {
        private string _grapheneWs;
        private string _grapheneWallet1Ws;
        private string _grapheneWallet2Ws;

        public GrapheneConfig(string grapheneWs,
            string grapheneWallet1Ws,
            string grapheneWallet2Ws)
        {
            _grapheneWs = grapheneWs;
            _grapheneWallet1Ws = grapheneWallet1Ws;
            _grapheneWallet2Ws = grapheneWallet2Ws;
        }

        public string GrapheneWs { get => _grapheneWs; set => _grapheneWs = value; }

        public string GrapheneWallet1Ws { get => _grapheneWallet1Ws; set => _grapheneWallet1Ws = value; }

        public string GrapheneWallet2Ws { get => _grapheneWallet2Ws; set => _grapheneWallet2Ws = value; }
    }
}
