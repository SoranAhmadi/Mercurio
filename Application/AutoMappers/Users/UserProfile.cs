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
        }
        private void Create()
        {
            CreateMap<UserCreateDTO, User>();
        }
    }
}
