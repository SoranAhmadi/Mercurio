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
            if (string.IsNullOrEmpty(overView.Image))
            {
                overView.Image = oldOverView.Image;
            }
            await base.Update(overView);
        }

    }
}
