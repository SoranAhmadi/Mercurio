using Application.DTOs.ContactUs;
using Application.DTOs.OVerViews;

namespace Application.IServices
{
    public interface IOverViewService
    {
        Task<OverViewDTO> Get();
        Task<int> Create(OverViewCreateDTO overViewCreateDTO);
        Task Update(OverViewUpdateDTO overViewUpdateDTO);

    }
}
