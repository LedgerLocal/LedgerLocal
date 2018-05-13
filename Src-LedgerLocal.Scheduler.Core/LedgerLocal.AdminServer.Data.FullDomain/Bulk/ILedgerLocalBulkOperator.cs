using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LedgerLocal.AdminServer.Data.FullDomain.Bulk
{
    public interface ILedgerLocalBulkOperator
    {
        Task BulkInsertBulkCopy<EntitySimple>(List<EntitySimple> list, IList<Tuple<string, string>> mappings, string destinationTable, int batchSize);
    }
}
