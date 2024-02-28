using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbContextMericurio context) : base(context)
        {
        }

        public IQueryable<Product> GetByCategoryAsync(string Category)
        {
            if (string.IsNullOrEmpty(Category) || Category.ToLower() == "all")
            {
                return context.Set<Product>().AsNoTracking().AsQueryable();
            }
            return context.Set<Product>().AsNoTracking().Where(p => p.Category.Title.ToLower() == Category.ToLower()).AsQueryable();
        }
        public async new Task Update(Product product)
        {
            var oldProduct = await context.Set<Product>().FirstOrDefaultAsync(p => p.Id == product.Id);
            oldProduct.CategoryId = product.CategoryId;
            oldProduct.Title = product.Title;
            oldProduct.Description = product.Description;
            if (!string.IsNullOrEmpty(product.ImageBase64))
            {
                oldProduct.ImageBase64 = product.ImageBase64;
            }
            if (!string.IsNullOrEmpty(product.Thumbnail))
            {
                oldProduct.Thumbnail = product.Thumbnail;
            }


            await context.SaveChangesAsync();

        }
        public IQueryable<Product> SearchProduct(string searchTerm)
        => context.Set<Product>().AsNoTracking().Where(p => p.Title.ToLower().Contains(searchTerm.ToLower())).AsQueryable();


    }
}
