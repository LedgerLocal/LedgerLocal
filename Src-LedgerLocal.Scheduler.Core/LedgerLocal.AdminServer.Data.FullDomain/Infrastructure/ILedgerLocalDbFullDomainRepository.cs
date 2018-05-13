using Common.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedgerLocal.AdminServer.Data.FullDomain.Infrastructure
{
    public interface ILedgerLocalDbFullDomainRepository<T> : IRepository<T> 
        where T : class
    {
    }
}
