using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;

namespace Infrastructure.Repositories
{
    
    public class ContactCommentRepository : Repository<ContactComment>, IContactCommentRepository
    {
        public ContactCommentRepository(DbContextMericurio context) : base(context)
        {
        }

    }
}
