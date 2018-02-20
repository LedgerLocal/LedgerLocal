using Common.Core;
using Common.Data.Infrastructure;

namespace LedgerLocal.FrontServer.Data.FullDomain.Infrastructure
{
    public class LedgerLocalDbFullDomainDatabaseFactory : Disposable, IDatabaseFactory<LedgerLocalDbContext>
    {
        private LedgerLocalDbContext _dataContext;
        private readonly object _syncObject = new object();
        private readonly string _connectionString;

        public LedgerLocalDbFullDomainDatabaseFactory(string connectionString)
        {
            _connectionString = connectionString;
            _dataContext = new LedgerLocalDbContext(_connectionString);
        }

        public LedgerLocalDbContext Get()
        {
            if (_dataContext != null)
            {
                lock (_syncObject)
                {
                    if (_dataContext != null)
                    {
                        return _dataContext;
                    }
                }
            }
            return null;
        }

        protected override void DisposeCore()
        {
            if (_dataContext != null)
            {
                _dataContext.Dispose();
            }
        }

        public void Refresh()
        {
            if (_dataContext != null)
            {
                lock (_syncObject)
                {
                    if (_dataContext != null)
                    {
                        _dataContext.Dispose();
                        _dataContext = new LedgerLocalDbContext(_connectionString);
                    }
                }
            }
        }

        public string ConnectionString()
        {
            return _connectionString;
        }
    }
}
