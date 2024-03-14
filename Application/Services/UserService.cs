using Application.DTOs.Users;
using Application.IServices;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHistoryRepository _historyRepository;
        private readonly IEmailSender _emailSender;
        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration config,
            IHttpContextAccessor httpContextAccessor, IHistoryRepository historyRepository, IEmailSender emailSender)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
            _historyRepository = historyRepository;
            _emailSender = emailSender;
        }
        public async Task<IEnumerable<UserDTO>> GetAll()
    => await _userRepository.GetAllQueryAble().ProjectTo<UserDTO>(_mapper.ConfigurationProvider).ToListAsync();

        public async Task Create(UserCreateDTO userCreate)
        {

            var user = _mapper.Map<User>(userCreate);
            Account account = new Account();
            user.Password = account.HashPasword(user.Password, out var salt);
            user.Salt = salt;
            user.Image = SaveImage(userCreate.ImageBase64);
            var result = await _userRepository.Insert(user);
            var newHistory = new History(nameof(User), ActionType.Create, _httpContextAccessor.GetUserId(), result);
            await _historyRepository.Insert(newHistory);

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

        public async Task Delete(int id)
        {
            await _userRepository.DeleteById(id);
            var newHistory = new History(nameof(User), ActionType.Delete, _httpContextAccessor.GetUserId(), id);
            await _historyRepository.Insert(newHistory);

        }


        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {

                new Claim("FullName",string.Format("{0} {1}",user.FirstName, user.LastName)),
                new Claim("Email", user.UserName),
                new Claim("Id", user.Id.ToString()),
                new Claim("Image",string.IsNullOrEmpty(user.Image)? "notfound.png":user.Image ),
                new Claim("Type", Enum.GetName(user.UserType).ToString()),

            };
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string SaveImage(string imageBase64)
        {
            var strGuid = Guid.NewGuid().ToString();
            var base64array = Convert.FromBase64String(imageBase64.Substring(imageBase64.LastIndexOf(',') + 1));
            var filePath = Path.Combine($"wwwroot/img/user/{strGuid}.jpg");
            System.IO.File.WriteAllBytes(filePath, base64array);
            return strGuid + ".jpg";

        }
        public async Task UpdatePassword(ForgetPasswordDTO forgetPasswordDTO)
        {
            var currentUser = await _userRepository.GetByUserName(forgetPasswordDTO.UserName);
            Account account = new Account();
            currentUser.Password = account.HashPasword(forgetPasswordDTO.Password, out var salt);
            currentUser.Salt = salt;
            await _userRepository.Update(currentUser);
        }

        public async Task<bool> UpdateMyPassword(string password)
        {
            var currentUser = await _userRepository.GetByUserName(_httpContextAccessor.GetUserName());
            if (_httpContextAccessor.GetUserId() != currentUser.Id)
                return false;
            Account account = new Account();
            currentUser.Password = account.HashPasword(password, out var salt);
            currentUser.Salt = salt;
            await _userRepository.Update(currentUser);
            return true;
        }
        public async Task<bool> SendPassByEmail(string gmail)
        {
            Random random = new Random();
            int randomBetween100And500 = random.Next(90000, 100000);
            var message = new Message(new string[] { gmail }, "Recovery Password", $"Your new password chnaged to:{randomBetween100And500}.", null);
            var result = await _emailSender.SendEmailAsync(message);
            if (result)
            {
                await UpdatePassword(new() { Password = randomBetween100And500.ToString(), UserName = gmail });
            }
            return result;

        }
        public async Task<bool> ExistEmail(string email)
        {
            return await _userRepository.GetByUserName(email) == null ? false : true;
        }






    }
}
