using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : Entity
    {

        Task<IEnumerable<T>> GetAll();
        IQueryable<T> GetAllQueryAble();
        Task<T?> Get(int id);
        Task<int> Insert(T entity);
        Task Update(T entity);
        void Delete(T entity);
        Task DeleteById(int id);

    }
}
