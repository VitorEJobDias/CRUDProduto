using System.Linq.Expressions;

namespace CRUDProduto.Core.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task CreateAsync(T entity);
        Task CreateAsync(List<T> entitys);
        void Update(T entity);
        void Update(List<T> entitys);
        IQueryable<T> GetAllAsync(bool tracking = false);
        Task<IEnumerable<T>> Search(Expression<Func<T, bool>> criteria, Func<IQueryable<T>, IQueryable<T>>? includes = null, bool tracking = true);
    }
}
