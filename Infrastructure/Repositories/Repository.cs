    using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly DbContextMericurio context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public Repository(DbContextMericurio context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return entities.AsNoTracking().AsQueryable();
        }

        public IQueryable<T> GetAllQueryAble() => entities.AsNoTracking().AsQueryable();

        public async Task<T?> Get(int id)
        {
            return await entities.SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<int> Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var entityInserted = await entities.AddAsync(entity);
            await context.SaveChangesAsync();
            return entityInserted.Entity.Id;
        }
        public async Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Update(entity);
            await context.SaveChangesAsync();
        }
        public async void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteById(int id)
        {
            var entity = await Get(id);
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
