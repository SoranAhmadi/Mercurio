using Application.DTOs.Category;

namespace Application.IServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAll();
        Task<int> Create(CategoryCreateDTO categoryCreateDTO);
        Task<CategoryUpdateDTO> GetById(int id);
        Task Update(CategoryUpdateDTO category);
        Task Delete(CategoryDeleteDTO category);

    }
}
