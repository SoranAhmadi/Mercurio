using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;

namespace Infrastructure.Repositories
{
    public class UserRepository:Repository<User>, IUserRepository
    {
        public UserRepository(DbContextMericurio context) : base(context)
        {
        }
    }
}
