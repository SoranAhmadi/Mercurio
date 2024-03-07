using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
       new Task<int> Insert(User user);
    }
}
