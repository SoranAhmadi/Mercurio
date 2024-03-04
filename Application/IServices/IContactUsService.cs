using Application.DTOs.ContactUs;

namespace Application.IServices
{
    public interface IContactUsService
    {
        Task<ContactUsDTO> Get();
        Task<int> Create(ContactUsCreateDTO contactUsCreateDTO);
        Task Update(ContactUsUpdateDTO contactUsUpdateDTO);

    }
}
