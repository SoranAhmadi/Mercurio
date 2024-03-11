using Application.DTOs.Product;
using Application.DTOs.Service;
using Domain.Entities;

namespace Application.IServices
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceDTO>> GetAll();
        Task<IEnumerable<ServiceSummaryDTO>> GetAllSummary();
        Task<int> Create(ServiceCreateDTO productCreateDTO);
        Task Delete(ServiceDeleteDTO delete);
        Task<ServiceUpdateDTO> GetById(int id);
        Task Update(ServiceUpdateDTO serviceUpdateDTO);
        Task UpdateSummary(ServiceUpdateSummaryDTO summary);

    }
}
