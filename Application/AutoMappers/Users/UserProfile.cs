using Application.DTOs.Users;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMappers.Users
{
    public sealed class UserProfile:Profile
    {
        public UserProfile() 
        {
            Create();
            Read();
        }
        private void Create()
        {
            CreateMap<UserCreateDTO, User>();
        }

        private void Read()
        {
            CreateMap< User, UserDTO>()
                .ForMember(dest => dest.UserType, opt => opt.MapFrom(src => Enum.GetName(src.UserType)))
                ;
        }
    }
}
