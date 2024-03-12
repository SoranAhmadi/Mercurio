using Application.DTOs.Category;
using Application.IServices;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepsitory;
        private readonly IHistoryRepository _historyRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper,
            IHistoryRepository historyRepository, IHttpContextAccessor httpContextAccessor)
        {
            _categoryRepsitory = categoryRepository;
            _mapper = mapper;
            _historyRepository = historyRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IEnumerable<CategoryDTO>> GetAll()
            => await _categoryRepsitory.GetAllQueryAble().ProjectTo<CategoryDTO>(_mapper.ConfigurationProvider).ToListAsync();

        public async Task<IEnumerable<CategoryWithImageDTO>> GetAllWithImage()
           => await _categoryRepsitory.GetAllQueryAble().ProjectTo<CategoryWithImageDTO>(_mapper.ConfigurationProvider).ToListAsync();

        public async Task<int> Create(CategoryCreateDTO categoryCreateDTO)
        {
            var result = await _categoryRepsitory.Insert(_mapper.Map<Category>(categoryCreateDTO));
            var newHistory = new History(nameof(Category), ActionType.Create, _httpContextAccessor.GetUserId(),result);
            await _historyRepository.Insert(newHistory);
            return result;
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
