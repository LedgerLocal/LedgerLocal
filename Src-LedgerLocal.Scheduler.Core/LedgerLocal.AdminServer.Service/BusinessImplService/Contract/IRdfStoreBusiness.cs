using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using VDS.RDF;

namespace LedgerLocal.AdminServer.Service.BusinessImplService.Contract
{
    public interface IRdfStoreBusiness
    {
        Tuple<Dictionary<string, object>, IList<Triple>> SaveJsonObjectWithGraph(JObject obj1, Type dtoType, Graph h, DateTime timestamp, string prefix);
        

    }
}
