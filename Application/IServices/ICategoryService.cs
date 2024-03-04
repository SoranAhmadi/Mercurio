using Application.DTOs.Category;

namespace Application.IServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAll();
        Task<IEnumerable<CategoryWithImageDTO>> GetAllWithImage();
        Task<int> Create(CategoryCreateDTO categoryCreateDTO);
        Task<CategoryUpdateDTO> GetById(int id);
        Task Update(CategoryUpdateDTO category);
        Task Delete(CategoryDeleteDTO category);

    }
}
