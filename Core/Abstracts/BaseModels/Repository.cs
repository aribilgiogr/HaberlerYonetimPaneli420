using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Abstracts.BaseModels
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _set;

        protected Repository(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>>? where = null)
        {
            return where == null ? await _set.AnyAsync() : await _set.AnyAsync(where);
        }

        public virtual async Task<int> CountAsync(Expression<Func<T, bool>>? where = null)
        {
            return where == null ? await _set.CountAsync() : await _set.CountAsync(where);
        }

        public virtual async Task CreateAsync(T entity) => await _set.AddAsync(entity);

        public virtual async Task CreateManyAsync(IEnumerable<T> entities) => await _set.AddRangeAsync(entities);

        public virtual async Task DeleteAsync(object id)
        {
            T? entity = await ReadByIdAsync(id);
            if (entity != null)
            {
                _set.Remove(entity);
            }
        }

        public virtual async Task<T?> ReadByIdAsync(object id) => await _set.FindAsync(id);

        public virtual async Task<IEnumerable<T>> ReadManyAsync(Expression<Func<T, bool>>? where = null, params string[] includes)
        {
            IQueryable<T> data = where == null ? _set : _set.Where(where);

            foreach (string include in includes)
            {
                data = data.Include(include);
            }

            return await data.ToListAsync();
        }

        public virtual async Task UpdateAsync(T entity) => await Task.Run(() => _set.Update(entity));

        public virtual async Task UpdateMany(IEnumerable<T> entities) => await Task.Run(() => _set.UpdateRange(entities));
    }
}
