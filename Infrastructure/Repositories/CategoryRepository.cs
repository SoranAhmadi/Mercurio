using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContextMericurio context) : base(context)
        {

        }

        public async new Task Update(Category entity)
        {
            var oldCategory = await context.Set<Category>().FirstOrDefaultAsync();
            if (string.IsNullOrEmpty(entity.ImageBase64))
            {
                entity.ImageBase64 = oldCategory.ImageBase64;
            }
            await base.Update(entity);
        }

    }
}
