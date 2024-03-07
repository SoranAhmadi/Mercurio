using Application.DTOs.Users;
using Application.IServices;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration config)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _config = config;
        }
        public async Task Create(UserCreateDTO userCreate)
        {

            var user = _mapper.Map<User>(userCreate);
            Account account = new Account();
            user.Password = account.HashPasword(user.Password, out var salt);
            user.Salt = salt;
            await _userRepository.Insert(user);
        }
        public async Task<string> Autonticate(AuthenticateDTO authenticateDTO)
        {
            User user = await _userRepository.GetByUserName(authenticateDTO.UserName);
            if (user is null)
            {
                return string.Empty;
            }
            Account account = new Account();
            var isCorrect = account.VerifyPassword(authenticateDTO.Password, user.Password, user.Salt);
            if (!isCorrect)
            {
                return string.Empty;
            }
            else return GenerateToken(user);
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                
                new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                new Claim(ClaimTypes.Email, user.UserName),
                
            };
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }




    }
}
