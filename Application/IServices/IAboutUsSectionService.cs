using Application.DTOs.AboutUsSections;

namespace Application.IServices
{
    public interface IAboutUsSectionService
    {
        Task<IEnumerable<AboutUsSectionRowDTO>> GetAll();
    }
}
