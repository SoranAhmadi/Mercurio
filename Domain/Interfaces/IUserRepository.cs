using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        new Task<int> Insert(User user);
        Task<User> Autonticate(string userName, string password);
        Task<User> GetByUserName(string userName);
    }
}
