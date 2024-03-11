using Domain.Entities;

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
        Task UpdateSummary(Service service);
        new Task Update(Service entity);


    }
}
