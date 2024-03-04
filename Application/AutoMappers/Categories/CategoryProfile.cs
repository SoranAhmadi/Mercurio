using Application.DTOs.Category;
using AutoMapper;
using Domain.Entities;
namespace Application.AutoMappers.Categories
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>();
            ReadWithImage();
        }

        private void ReadWithImage()
        {
            CreateMap<Category, CategoryWithImageDTO>();
        }
    }
}
