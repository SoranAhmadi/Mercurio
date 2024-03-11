using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        public ServiceRepository(DbContextMericurio context) : base(context)
        {
        }
        public async Task<List<ServiceItem>> GetAllServiceItems()
        {
            return await context.Set<ServiceItem>().AsNoTracking().ToListAsync();
        }

        public IQueryable<Service> GetAllService()
        {
            return context.Set<Service>().Include(s => s.ServiceItems).AsSingleQuery().AsNoTracking();
        }

        public new IQueryable<Service> GetAllQueryAble()
            => context.Set<Service>().Include(s => s.ServiceItems).AsSplitQuery().AsNoTracking();
        

        public async new Task Delete(int id)
        {
            var services = await context.Set<ServiceItem>().Where(s => s.ServiceId == id).ToListAsync();
            context.Set<ServiceItem>().RemoveRange(services);
            var service = await context.Set<Service>().FirstOrDefaultAsync(s => s.Id == id);
            context.Set<Service>().Remove(service);
            await context.SaveChangesAsync();
        }

        public async Task<Service> GetById(int id)
        {
            var result = await context.Set<Service>().Include(c => c.ServiceItems).FirstOrDefaultAsync(s => s.Id == id);
            return result;
        }

        public async Task DeleteServiceItems(int serviceId)
        {
            var serviceItems = await context.Set<ServiceItem>().Where(si => si.ServiceId == serviceId).AsNoTracking().ToListAsync();
            context.Set<ServiceItem>().RemoveRange(serviceItems);
            await context.SaveChangesAsync();
        }

        public async Task AddServiceItems(List<ServiceItem> serviceItems)
        {
            await context.Set<ServiceItem>().AddRangeAsync(serviceItems);
            await context.SaveChangesAsync();
        }

        public async Task UpdateSummary(Service service)
        {
            var oldService = await context.Set<Service>().FirstOrDefaultAsync(s=>s.Id == service.Id);
            oldService.Title = service.Title; 
            oldService.Description = service.Description;
            if (!string.IsNullOrEmpty(service.ImageBase64))
            {
                oldService.ImageBase64 = service.ImageBase64;
            }
            await context.SaveChangesAsync();
        }
       public async new Task Update(Service entity)
        {
            var old = await context.Set<Service>().AsNoTracking().FirstOrDefaultAsync(s => s.Id == entity.Id);
            entity.Description = old.Description;
            if (string.IsNullOrEmpty(entity.ImageBase64))
            {
                entity.ImageBase64 = old.ImageBase64;
            }
            await base.Update(entity);
        }

    }
}
