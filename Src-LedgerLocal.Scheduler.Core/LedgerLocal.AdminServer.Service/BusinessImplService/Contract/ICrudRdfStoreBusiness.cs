using System;
using System.Collections.Generic;
using System.Text;
using VDS.RDF;

namespace LedgerLocal.AdminServer.Service.BusinessImplService.Contract
{
    public interface ICrudRdfStoreBusiness
    {
        Tuple<T, IList<Triple>> SaveOrUpdateObject<T>(T obj1, Func<T, string> idFunc)
                   where T : class;

        T GetObject<T>(Func<T, bool> where)
            where T : class;

        List<T> GetObjects<T>()
            where T : class;

    }
}
