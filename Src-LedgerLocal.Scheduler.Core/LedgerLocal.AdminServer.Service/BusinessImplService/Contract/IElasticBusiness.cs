using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerLocal.AdminServer.Service.BusinessImplService.Contract
{
    public interface IElasticBusiness
    {
        void IndexJsonObject(IEnumerable<Dictionary<string, object>> obj1, string indexName, string type);

    }
}
