using Application.DTOs.Product;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMappers.Products
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            Create();
            Read();
            Update();
            Search();
        }
        private void Create()
        {
            CreateMap<ProductCreateDTO, Product>();
        }

        private void Read()
        {
            CreateMap<Product, ProductDTO>();
        }
        private void Update()
        {
            CreateMap<ProductUpdateDTO, Product>().ReverseMap();
        }

        private void Search()
        {
            CreateMap<Product, ProductSearchViewDTO>().ReverseMap();
        }
    }
}
