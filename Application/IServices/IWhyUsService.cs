using Application.DTOs.Service;
using Application.DTOs.WhyUses;

namespace Application.IServices
{
    public interface IWhyUsService
    {
        Task<IEnumerable<WhyUsDTO>> GetAll();
        Task<int> Create(WhyUsCreateDTO whyUsCreateDTO);
        Task Delete(WhyUsDeleteDTO delete);
        Task<WhyUsUpdateDTO> GetById(WhyUsByIdDTO whyUsByIdDTO);
        Task Update(WhyUsUpdateDTO whyUsUpdateDTO);

    }
}
