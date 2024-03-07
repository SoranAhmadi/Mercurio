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
            AboutUsOnly();
            AboutUsOnly();
            OurCompany();
            InsertAboutUs();
            InsertOurCompany();
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
            CreateMap<AboutUsSection, AboutUsDetailDTO>().ReverseMap();
            
        }
        private void AboutUsOnly()
        {
            CreateMap<AboutUsSection, OurCompanyDTO>().ReverseMap();
        }
        private void OurCompany()
        {
            CreateMap<AboutUsSection, AboutUsOnlyDTO>();
        }
        private void InsertAboutUs()
        {
            CreateMap<AboutUsSection, AboutUsInsertOrUpdateDTO>().ReverseMap();
        }
        private void InsertOurCompany()
        {
            CreateMap<AboutUsSection, OurCompanyInsertOrUpdateDTO>().ReverseMap();
        }
    }
   
}
