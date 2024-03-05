using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;

namespace Infrastructure.Repositories
{
    public class OverViewRepository:Repository<OverView>, IOverViewRepository
    {
        public OverViewRepository(DbContextMericurio context) : base(context)
        {
        }
    }
}
