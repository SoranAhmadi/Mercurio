using Application.DTOs.Category;
using Application.IServices;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepsitory;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepsitory = categoryRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDTO>> GetAll()
            =>await _categoryRepsitory.GetAllQueryAble().ProjectTo<CategoryDTO>(_mapper.ConfigurationProvider).ToListAsync();

        public async Task<int> Create(CategoryCreateDTO categoryCreateDTO)
        {
            return await _categoryRepsitory.Insert(_mapper.Map<Category>(categoryCreateDTO));
        }
        public async Task<CategoryUpdateDTO> GetById(int id)
        {
            var category = await _categoryRepsitory.Get(id);
            return _mapper.Map<CategoryUpdateDTO>(category);
        }
        public async Task Update(CategoryUpdateDTO category)
        => await _categoryRepsitory.Update(_mapper.Map<Category>(category));

        public async Task Delete(CategoryDeleteDTO category)
        => await _categoryRepsitory.DeleteById(category.Id);
    }
}
