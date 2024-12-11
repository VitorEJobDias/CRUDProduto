using Microsoft.EntityFrameworkCore.Query;
using CRUDProduto.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using CRUDProduto.Core.Common;
using System.Linq.Expressions;

namespace CRUDProduto.Infrastructure.Persistence.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(DbContext dbContext)
        {
            _context = dbContext;
            _dbSet = _context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task CreateAsync(List<T> entitys)
        {
            await _context.Set<T>().AddRangeAsync(entitys);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Update(List<T> entitys)
        {
            _context.Set<T>().UpdateRange(entitys);
        }

        public virtual async Task<IEnumerable<T>> Search(Expression<Func<T, bool>> consulta, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool tracking = false)
        {
            IQueryable<T> query = _dbSet;

            if (include != null)
            {
                query = include(query);
            }

            if (!tracking)
            {
                query = query.AsNoTracking();
            }

            return await query.Where(consulta).AsNoTracking().ToListAsync();
        }

        public IQueryable<T> GetAllAsync(bool tracking = false)
        {
            if (!tracking) return _context.Set<T>().AsNoTracking();
            return _context.Set<T>();
        }
    }
}
