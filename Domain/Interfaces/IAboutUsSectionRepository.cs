using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IAboutUsSectionRepository:IRepository<AboutUsSection>
    {
        Task InsertOrUpdateAboutUs(AboutUsSection aboutUsSection);
        Task InsertOrUpdateOurCompany(AboutUsSection ourCompany);
    }
}
