using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;

namespace Infrastructure.Repositories
{
    public class AboutUsSectionRepository:Repository<AboutUsSection>, IAboutUsSectionRepository
    {
        public AboutUsSectionRepository(DbContextMericurio context) : base(context)
        {

        }
    }
}
