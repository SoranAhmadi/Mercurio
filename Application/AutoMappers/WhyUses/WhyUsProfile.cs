using Application.DTOs.WhyUses;
using AutoMapper;
using Domain.Entities;
namespace Application.AutoMappers.WhyUses
{
    public class WhyUsProfile:Profile
    {
        public WhyUsProfile() 
        {
            Read();
            Create();
            Update();
        }
        private void Create()
        {
            CreateMap<WhyUsCreateDTO, WhyUs>();
        }
        private void Read()
        {
            CreateMap<WhyUs, WhyUsDTO>();
        }
        private void Update()
        {
            CreateMap<WhyUsUpdateDTO, WhyUs>().ReverseMap();
        }

    }
}
