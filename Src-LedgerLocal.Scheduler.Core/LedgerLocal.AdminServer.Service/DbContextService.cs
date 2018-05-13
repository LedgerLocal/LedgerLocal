using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Data.Infrastructure;
using LedgerLocal.AdminServer.Data.FullDomain;
using LedgerLocal.AdminServer.Service.Contract;

namespace LedgerLocal.AdminServer.Service
{
    public class DbContextService : IDbContextService
    {
        private readonly IDatabaseFactory<LedgerLocalDbContext> _databaseFactory;

        public DbContextService(IDatabaseFactory<LedgerLocalDbContext> databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public void RefreshFullDomain()
        {
            _databaseFactory.Refresh();
        }
    }
}
