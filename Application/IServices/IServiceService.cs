using Application.DTOs.Product;
using Application.DTOs.Service;

namespace Application.IServices
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceDTO>> GetAll();
        Task<int> Create(ServiceCreateDTO productCreateDTO);
        Task Delete(ServiceDeleteDTO delete);
        Task<ServiceUpdateDTO> GetById(int id);
        Task Update(ServiceUpdateDTO serviceUpdateDTO);



    }
}
