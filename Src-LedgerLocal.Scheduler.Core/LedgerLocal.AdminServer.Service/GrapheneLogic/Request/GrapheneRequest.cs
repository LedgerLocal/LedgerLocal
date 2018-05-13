using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.Service.GrapheneLogic.Request
{
    /// <summary>
    /// {"jsonrpc": "2.0", "method": "get_accounts", "params": [["1.2.0"]], "id": 1}
    /// </summary>
    public class GrapheneRequest
    {
        public decimal jsonrpc;
        public int id;
        public GrapheneMethodEnum method;
        public object[] @params;

        public GrapheneRequest(GrapheneMethodEnum method, params object[] @params)
        {
            this.jsonrpc = 2;
            this.id = 1;
            this.method = method;
            this.@params = @params;
        }
    }
}
