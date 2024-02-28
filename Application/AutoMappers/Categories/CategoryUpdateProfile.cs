using Application.DTOs.Category;
using AutoMapper;
using Domain.Entities;
namespace Application.AutoMappers.Categories
{
    public class CategoryUpdateProfile : Profile
    {
        public CategoryUpdateProfile()
        {
            CreateMap<CategoryUpdateDTO, Category>().ReverseMap();
        }
    }
}
