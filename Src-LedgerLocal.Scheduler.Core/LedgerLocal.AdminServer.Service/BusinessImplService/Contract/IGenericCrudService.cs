using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LedgerLocal.AdminServer.Dto;
using LedgerLocal.AdminServer.Model.FullDomain;

namespace LedgerLocal.AdminServer.Service.BusinessImplService.Contract
{
    public interface IGenericCrudService<TD, T>
        where TD : GenericDto
        where T : BaseEntity, new()
    {
        Task<TD> CreateAsync(TD pDto, Func<T, bool> keyPredicate);

        Task<TD> UpdateAsync(TD c1, Func<T, bool> keyPredicate);

        Task<IList<TD>> GetAllAsync(Func<DbSet<T>, IQueryable<T>> selectIncludes = null);

        Task<TD> GetSingleByPredicateAsync(Func<T, bool> predicate, Func<DbSet<T>, IQueryable<T>> selectIncludes = null);

        Task<List<TD>> GetListByPredicateAsync(Func<T, bool> predicate, Func<DbSet<T>, IQueryable<T>> selectIncludes = null);

        Task DeleteAsync(TD c1, Func<T, bool> keyPredicate);
    }
}
