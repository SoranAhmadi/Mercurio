using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;

namespace Infrastructure.Repositories
{
    public class WhyUsRepository:Repository<WhyUs>, IWhyUsRepository
    {
        public WhyUsRepository(DbContextMericurio context) : base(context)
        {
        }
    }
}
