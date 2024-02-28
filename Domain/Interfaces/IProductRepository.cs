using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProductRepository: IRepository<Product>
    {
        IQueryable<Product> GetByCategoryAsync(string CategoryId);
        IQueryable<Product> SearchProduct(string searchTerm);
        new Task Update(Product product);
    }
}
