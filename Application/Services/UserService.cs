using Application.DTOs.Users;
using Application.IServices;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task Create(UserCreateDTO userCreate)
        {

            var user = _mapper.Map<User>(userCreate);
            Account account = new Account();
            account.HashPasword(user.Password, out var salt);
            user.Salt = salt;
            await _userRepository.Insert(user);
        }
        public async Task<string> Autonticate(AuthenticateDTO authenticateDTO)
        {
            User user = await _userRepository.GetByUserName(authenticateDTO.UserName);
            if (user is null)
            {
                throw new Exception("The username or password is incorrect");
            }
            Account account = new Account();
            var isCorrect = account.VerifyPassword(authenticateDTO.Password, user.Password, user.Salt);
            if (!isCorrect)
            {
                throw new Exception("The username or password is incorrect");
            }
            else return string.Empty;
        }




    }
}
