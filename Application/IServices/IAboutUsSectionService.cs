using Application.DTOs.AboutUsSections;
using Application.DTOs.Category;

namespace Application.IServices
{
    public interface IAboutUsSectionService
    {
        Task<IEnumerable<AboutUsSectionRowDTO>> GetAll();
        Task<int> Create(AboutUsSectionCreateDTO aboutUsSectionCreate);
        Task<AboutUsSectionUpdateDTO> GetById(int id);
        Task Update(AboutUsSectionUpdateDTO category);
        Task Delete(AboutUsSectionDeleteDTO category);

    }
}
