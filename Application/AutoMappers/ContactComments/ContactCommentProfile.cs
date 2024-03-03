using Application.DTOs.Category;
using Application.DTOs.ContactComment;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMappers.ContactComments
{
    
    public class ContactCommentProfile : Profile
    {
        public ContactCommentProfile()
        {
            Read();
            Update();
            Create();
        }
        private void Create()
        {
            CreateMap< ContactCommentCreateDTO,ContactComment > ();
        }
        private void Update() {
            CreateMap<ContactComment, ContactCommentUpdateDTO>().ReverseMap();
        }
        private void Read()
        {
            CreateMap<ContactComment, ContactCommentDTO>();
        }
    }
}
