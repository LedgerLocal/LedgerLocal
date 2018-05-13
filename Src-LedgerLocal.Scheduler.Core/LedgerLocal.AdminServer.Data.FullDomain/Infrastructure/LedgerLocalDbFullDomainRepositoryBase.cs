using Common.Data.Infrastructure;

namespace LedgerLocal.AdminServer.Data.FullDomain.Infrastructure
{
    public class LedgerLocalDbFullDomainRepositoryBase<T> : RepositoryBase<T, LedgerLocalDbContext>, ILedgerLocalDbFullDomainRepository<T>
        where T : class
    {
        public LedgerLocalDbFullDomainRepositoryBase(IDatabaseFactory<LedgerLocalDbContext> databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
