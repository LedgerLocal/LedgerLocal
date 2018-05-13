using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.Service.GrapheneLogic
{
    public class GrapheneRpcException : Exception
    {
        private string _error;

        public GrapheneRpcException(string error)
        {
            _error = error;
        }

        public override string Message { get { return _error; } }
    }
}
