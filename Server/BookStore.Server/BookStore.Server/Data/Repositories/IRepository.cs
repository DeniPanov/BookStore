using System.Linq.Expressions;

namespace BookStore.Server.Data.Repositories
{
    public interface IRepository<T> where T : class, new()
    {
        IQueryable<T> All(params Expression<Func<T, object>>[] includeExpressions);

        T GetById(object id);

        Task<T> GetByIdAsync(object id);

        T Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Delete(T entity);

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
