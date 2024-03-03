using Domain.Entities;
using Microsoft.VisualBasic.FileIO;

namespace Domain.Interfaces
{
    public interface IServiceRepository : IRepository<Service>
    {
        Task<List<ServiceItem>> GetAllServiceItems();
        IQueryable<Service> GetAllService();
        new IQueryable<Service> GetAllQueryAble();
        new Task Delete(int id);
        Task<Service> GetById(int id);
        Task DeleteServiceItems(int serviceId);
        Task AddServiceItems(List<ServiceItem> serviceItems);


    }
}
