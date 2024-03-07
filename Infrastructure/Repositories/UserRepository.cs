using Domain.Common;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContextMericurio context) : base(context)
        {
        }
        public async new Task<int> Insert(User user)
        {
            var exist = await context.Set<User>().AnyAsync(u => u.UserName == user.UserName.Trim());
            if (exist)
                throw new NotImplementedException("The Username exist");

           return await base.Insert(user);
        }
        public async Task<User> Autonticate(string userName, string password)
        {
            var user = await context.Set<User>().FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);
            if (user is null)
                throw new NotImplementedException("The Username or Passord is incorrect");
            return user;
        }
        public async Task<User> GetByUserName(string userName)
        {
            User user = await context.Set<User>().AsNoTracking().FirstOrDefaultAsync(user => user.UserName == userName.Trim());
            return user;
        }
    }
}
