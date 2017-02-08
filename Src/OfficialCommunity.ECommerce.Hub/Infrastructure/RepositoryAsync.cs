using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OfficialCommunity.ECommerce.Hub.Data;
using OfficialCommunity.ECommerce.Hub.Domains.Infrastructure;
using OfficialCommunity.ECommerce.Hub.Extensions;

namespace OfficialCommunity.ECommerce.Hub.Infrastructure
{
    public class RepositoryAsync<T> : IRepositoryAsync<T>
        where T : class, IBaseEntity
    {
        private readonly ECommerceDbContext _context;

        public RepositoryAsync(ECommerceDbContext context)
        {
            _context = context;
        }

        public override int GetHashCode()
        {
            return _context.GetHashCode();
        }

        public DbContext DbContext()
        {
            return _context;
        }

        public DbSet<T> Table()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> Query()
        {
            return _context.Set<T>();
        }

        public async Task<T> GetAsync(Guid? id)
        {
            if (!id.HasValue)
                return default(T);

            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().AnyAsync(match);
        }

        public async Task<T> FindSingleOrDefaultAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(match);
        }
        public async Task<T> FindFirstOrDefaultAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(match);
        }
        public async Task<IList<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().Where(match).ToListAsync();
        }

        public T Add(T t, bool saveChanges = true, string identity = null, bool generateNewId = true)
        {
            if (t == null)
                return null;

            if (generateNewId)
                t.Id = Guid.NewGuid();

            t.Timestamp(identity);

            _context.Set<T>().Add(t);

            if (saveChanges)
                _context.SaveChanges();

            return t;
        }

        public async Task<T> AddAsync(T t, bool saveChanges = true, string identity = null, bool generateNewID = true)
        {
            if (t == null)
                return null;

            if (generateNewID)
                t.Id = Guid.NewGuid();

            t.Timestamp(identity);

            _context.Set<T>().Add(t);

            if (saveChanges)
                await _context.SaveChangesAsync();

            return t;
        }

        public async Task<IEnumerable<T>> AddAllAsync(IEnumerable<T> tList, bool saveChanges = true, string identity = null)
        {
            if (tList == null)
                return null;

            var updatedList = tList.Select(x =>
            {
                x.Id = Guid.NewGuid();
                x.Timestamp(identity);
                return x;
            }).ToList();

            _context.Set<T>().AddRange(updatedList);

            if (saveChanges)
                await _context.SaveChangesAsync();

            return updatedList;
        }

        public async Task<IEnumerable<T>> UpdateAllAsync(IEnumerable<T> tList, bool saveChanges = true, string identity = null)
        {
            if (tList == null)
                return null;

            foreach (var t in tList)
            {
                var existing = await GetAsync(t.Id);
                if (existing == null) continue;
                _context.Entry(existing).UpdateProperties(t);
                existing.Timestamp();
            }

            if (saveChanges)
                await _context.SaveChangesAsync();

            return tList;
        }

        public async Task<T> UpdateAsync(T updated, bool saveChanges = true, string identity = null)
        {
            if (updated == null)
                return null;

            var existing = await GetAsync(updated.Id);
            if (existing == null)
                return null;

            _context.Entry(existing).UpdateProperties(updated);

            existing.Timestamp();

            if (saveChanges)
                await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<int> DeleteAsync(T t, bool saveChanges = true)
        {
            if (t == null)
                return -1;

            _context.Set<T>().Remove(t);

            if (saveChanges)
                return await _context.SaveChangesAsync();

            return 0;
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().CountAsync(match);
        }
    }
}
