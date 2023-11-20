using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookStore.Server.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly DbContext context;
        private readonly DbSet<T> entities;

        public Repository(BookStoreDbContext context)
        {
            this.context = context;
            this.entities = context.Set<T>();
        }

        public IQueryable<T> All(params Expression<Func<T, object>>[] includeExpressions)
        {
            return this.entities.AsQueryable();
        }

        public T GetById(object id)
        {
            return this.entities.Find(id);
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await this.entities.FindAsync(id);
        }

        public T Add(T entity)
        {
            return this.entities.Add(entity).Entity;
        }

        public void AddRange(IEnumerable<T> entities)
        {
            this.entities.AddRange(entities);
        }

        public void Delete(T entity)
        {
            this.entities.Remove(entity);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}
