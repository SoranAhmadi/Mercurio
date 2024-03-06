using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OverViewRepository:Repository<OverView>, IOverViewRepository
    {
        public OverViewRepository(DbContextMericurio context) : base(context)
        {
        }
        public new async Task Update(OverView overView)
        {
            var oldOverView =await context.Set<OverView>().AsNoTracking().FirstOrDefaultAsync(ov=>ov.Id == overView.Id);
            if (string.IsNullOrEmpty(overView.ImageBase64))
            {
                overView.ImageBase64 = oldOverView.ImageBase64;
            }
            await base.Update(overView);
        }

    }
}
