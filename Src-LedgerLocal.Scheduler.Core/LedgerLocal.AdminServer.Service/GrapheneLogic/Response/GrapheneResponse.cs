using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.Service.GrapheneLogic.Response
{
    public class GrapheneResponse<T>
    {
        public int id;
        public T result;
    }
}
