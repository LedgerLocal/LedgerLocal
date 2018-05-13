using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.Service.GrapheneLogic.Request
{
    public class GrapheneSocketRequest
    {
        readonly public int id;
        readonly public string method;
        public object[] @params;

        public GrapheneSocketRequest(GrapheneMethodEnum method, int id, int api, params object[] @params)
        {
            this.id = id;
            this.method = "call";

            object[] fudgeParams = { api, method.ToString(), @params };

            this.@params = fudgeParams;
        }

        public GrapheneSocketRequest(string method, int id, int api, params object[] @params)
        {
            this.id = id;
            this.method = "call";

            object[] fudgeParams = { api, method.ToString(), @params };

            this.@params = fudgeParams;
        }
    }
}
