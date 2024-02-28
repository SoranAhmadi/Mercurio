using Application.DTOs.Category;
using Application.DTOs.Product;

namespace Application.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAll(ProductFilterDTO? filter);
        Task<IEnumerable<ProductSearchViewDTO>> SearchProductTerm(ProductSearchDTO? searchTerm);
        Task<int> Create(ProductCreateDTO productCreateDTO);
        Task<ProductUpdateDTO> GetById(int id);
        Task Update(ProductUpdateDTO category);
        Task Delete(ProductDeleteDTO category);
    }
}
