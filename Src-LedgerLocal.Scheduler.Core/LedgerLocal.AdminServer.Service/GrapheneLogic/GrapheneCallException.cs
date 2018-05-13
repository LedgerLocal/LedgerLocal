using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.Service.GrapheneLogic
{
    public class GrapheneCallException : Exception
    {
        public GrapheneCallException(string error, Exception e) : base(error, e)
        {
        }
    }
}
