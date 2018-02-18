using Common.Data.Infrastructure;

namespace LedgerLocal.FrontServer.Data.FullDomain.Infrastructure
{
    public class LedgerLocalDbFullDomainRepositoryBase<T> : RepositoryBase<T, LedgerLocalDbMainContext>, ILedgerLocalDbFullDomainRepository<T>
        where T : class
    {
        public LedgerLocalDbFullDomainRepositoryBase(IDatabaseFactory<LedgerLocalDbMainContext> databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
