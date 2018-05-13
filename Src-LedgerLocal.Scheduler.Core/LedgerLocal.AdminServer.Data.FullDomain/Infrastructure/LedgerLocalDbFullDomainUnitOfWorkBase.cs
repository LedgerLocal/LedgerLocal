using Common.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace LedgerLocal.AdminServer.Data.FullDomain.Infrastructure
{
    public class LedgerLocalDbFullDomainUnitOfWorkBase : UnitOfWorkBase<LedgerLocalDbContext>, ILedgerLocalDbFullDomainUnitOfWork
    {
        private readonly Microsoft.Extensions.Logging.ILogger<LedgerLocalDbFullDomainUnitOfWorkBase> _logger;

        public LedgerLocalDbFullDomainUnitOfWorkBase(ILogger<LedgerLocalDbFullDomainUnitOfWorkBase> logger,
            IDatabaseFactory<LedgerLocalDbContext> databaseFactory)
            : base(databaseFactory)
        {
            _logger = logger;
        }

        public bool CommitHandled()
        {
            var errors = new List<Tuple<string, string>>();

            try
            {
                Commit();
            }
            catch (Exception e)
            {
                _logger.LogError(new EventId(370, "EntityFrameWork-Commit"), e, "Error during commit, not rethrowned.");
                return false;
            }

            return true;
        }

        public async Task<bool> CommitHandledAsync()
        {
            var errors = new List<Tuple<string, string>>();

            try
            {
                await DataContext.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                _logger.LogError(e.Message);

                return false;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
                
            return true;
        }
    }
}
