using Application.DTOs.ContactUs;
using Application.DTOs.OVerViews;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMappers.OverViews
{
    public class OverViewProfile:Profile
    {
        public OverViewProfile()
        {
            Create();
            Read();
            Update();
        }
        private void Read()
        {
            CreateMap<OverView, OverViewDTO>();
        }
        private void Create()
        {
            CreateMap<OverViewCreateDTO, OverView>();
        }
        private void Update()
        {
            CreateMap<OverViewUpdateDTO, OverView>().ReverseMap();
        }
    }

}
