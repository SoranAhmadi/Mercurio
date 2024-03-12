using Application.DTOs.Histories;

namespace Application.IServices
{
    public interface IHistoryService
    {
        Task<IEnumerable<HistoryDTO>> GetAll();
    }
}
