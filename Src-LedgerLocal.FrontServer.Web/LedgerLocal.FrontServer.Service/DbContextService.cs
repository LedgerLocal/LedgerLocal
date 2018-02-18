using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Data.Infrastructure;
using LedgerLocal.FrontServer.Data.FullDomain;
using LedgerLocal.FrontServer.Service.Contract;

namespace LedgerLocal.FrontServer.Service
{
    public class DbContextService : IDbContextService
    {
        private readonly IDatabaseFactory<LedgerLocalDbMainContext> _databaseFactory;

        public DbContextService(IDatabaseFactory<LedgerLocalDbMainContext> databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public void RefreshFullDomain()
        {
            _databaseFactory.Refresh();
        }
    }
}
