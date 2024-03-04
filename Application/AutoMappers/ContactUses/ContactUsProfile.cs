using Application.DTOs.ContactUs;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMappers.ContactUses
{
    public class ContactUsProfile : Profile
    {
        public ContactUsProfile()
        {
            Create();
            Read();
            Update();
        }
        private void Read()
        {
            CreateMap<ContactUs, ContactUsDTO>();
        }
        private void Create()
        {
            CreateMap<ContactUsCreateDTO, ContactUs>();
        }
        private void Update()
        {
            CreateMap<ContactUsUpdateDTO, ContactUs>().ReverseMap();
        }
    }
}
