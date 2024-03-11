using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;

namespace Infrastructure.Repositories
{
    public class HistoryRepository:Repository<History>, IHistoryRepository
    {
        public HistoryRepository(DbContextMericurio context) : base(context)
        {
        }

    }
}
