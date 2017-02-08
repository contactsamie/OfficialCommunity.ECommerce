using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OfficialCommunity.ECommerce.Hub.Domains.Infrastructure
{
    public interface IRepositoryAsync<T>
        where T : class, IBaseEntity
    {
        DbContext DbContext();
        DbSet<T> Table();
        IQueryable<T> Query();

        Task<T> GetAsync(Guid? id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> match);
        Task<T> FindSingleOrDefaultAsync(Expression<Func<T, bool>> match);
        Task<T> FindFirstOrDefaultAsync(Expression<Func<T, bool>> match);
        Task<IList<T>> FindAllAsync(Expression<Func<T, bool>> match);

        Task<T> AddAsync(T t, bool saveChanges = true, string identity = null, bool generateNewId = true);
        Task<IEnumerable<T>> AddAllAsync(IEnumerable<T> tList, bool saveChanges = true, string identity = null);

        Task<T> UpdateAsync(T updated, bool saveChanges = true, string identity = null);
        Task<IEnumerable<T>> UpdateAllAsync(IEnumerable<T> tList, bool saveChanges = true, string identity = null);

        Task<int> DeleteAsync(T t, bool saveChanges = true);

        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> match);
    }
}