using Application.DTOs.AboutUsSections;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMappers.AboutUsSections
{
    public class AboutUsSectionProfile:Profile
    {
        public AboutUsSectionProfile()
        {
            Create();
            Update();
            Items();
            AboutUsDetail();
        }

        private void Create()
        {
            CreateMap<AboutUsSectionCreateDTO, AboutUsSection>();
        }
        private void Update()
        {
            CreateMap<AboutUsSectionUpdateDTO, AboutUsSection>().ReverseMap();
        }
        private void Items()
        {
            CreateMap< AboutUsSection, AboutUsSectionItemDTO>();
        }
        private void AboutUsDetail()
        {
            CreateMap<AboutUsSection, AboutUsDetailDTO>();
            
        }
        
    }
   
}
