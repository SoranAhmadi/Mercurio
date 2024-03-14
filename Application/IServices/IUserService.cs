using Application.DTOs.Users;

namespace Application.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAll();
        Task Create(UserCreateDTO userCreate);
        Task<string> Autonticate(AuthenticateDTO authenticateDTO);
        Task Delete(int id);
        Task UpdatePassword(ForgetPasswordDTO forgetPasswordDTO);
        Task<bool> UpdateMyPassword(string password);
        Task<bool> SendPassByEmail(string gmail);
        Task<bool> ExistEmail(string email);
    }
}
