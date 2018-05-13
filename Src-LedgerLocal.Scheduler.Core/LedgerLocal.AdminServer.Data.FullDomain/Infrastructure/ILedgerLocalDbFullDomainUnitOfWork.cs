using Common.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedgerLocal.AdminServer.Data.FullDomain.Infrastructure
{
    public interface ILedgerLocalDbFullDomainUnitOfWork : IUnitOfWork
    {
        bool CommitHandled();
        Task<bool> CommitHandledAsync();
    }
}
