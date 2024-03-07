using Domain.Common.Enums;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AboutUsSectionRepository : Repository<AboutUsSection>, IAboutUsSectionRepository
    {
        public AboutUsSectionRepository(DbContextMericurio context) : base(context)
        {

        }

        public async Task InsertOrUpdateAboutUs(AboutUsSection aboutUsSection)
        {
            var allAboutUs = await context.Set<AboutUsSection>().AsNoTracking().Where(a => a.Type == AboutUsType.AboutUs).ToListAsync();
            await base.RemoveRange(allAboutUs);
            await base.Insert(aboutUsSection);
        }
        public async Task InsertOrUpdateOurCompany(AboutUsSection ourCompany)
        {
            var ourCompanies = await context.Set<AboutUsSection>().AsNoTracking().Where(a => a.Type == AboutUsType.OurCompany).ToListAsync();
            await base.RemoveRange(ourCompanies);
            await base.Insert(ourCompany);
        }
    }
}
