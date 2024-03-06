using Application.DTOs.AboutUsSections;

namespace Application.IServices
{
    public interface IAboutUsSectionService
    {
        Task<IEnumerable<AboutUsSectionRowDTO>> GetAll();
        Task<IEnumerable<AboutUsDetailDTO>> GetAllWithDetail();
        Task<int> Create(AboutUsSectionCreateDTO aboutUsSectionCreate);
        Task<AboutUsSectionUpdateDTO> GetById(int id);
        Task Update(AboutUsSectionUpdateDTO category);
        Task Delete(AboutUsSectionDeleteDTO category);

    }
}
