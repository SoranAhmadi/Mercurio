using Application.DTOs.Category;
using AutoMapper;
using Domain.Entities;
namespace Application.AutoMappers.Categories
{
    public class CategoryCreateProfile: Profile
    {
        public CategoryCreateProfile()
        {
            CreateMap<CategoryCreateDTO, Category>();
        }
    }
}
