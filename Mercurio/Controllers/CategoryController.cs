using Application.DTOs.Category;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Mercurio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryRepository;
        public CategoryController(ICategoryService categoryRepository)
        {
            _categoryRepository= categoryRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> GetAll()=>await _categoryRepository.GetAll();

        [HttpPost]
        public async Task<CategoryUpdateDTO> GetById(CategoryDeleteDTO categoryDeleteDTO) => await _categoryRepository.GetById(categoryDeleteDTO.Id);

        [HttpPost]
        public async Task<int> Create(CategoryCreateDTO categoryCreateDTO) => await _categoryRepository.Create(categoryCreateDTO);

        [HttpPut]
        public async Task Update(CategoryUpdateDTO categoryUpdateDTO) => await _categoryRepository.Update(categoryUpdateDTO);
        
        [HttpDelete]
        public async Task Delete(CategoryDeleteDTO categoryDeleteDTO) => await _categoryRepository.Delete(categoryDeleteDTO);


    }
}
