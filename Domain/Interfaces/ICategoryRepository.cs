using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
       new Task Update(Category entity);
    }
}
