using Application.DTOs.Users;

namespace Application.IServices
{
    public interface IUserService
    {
        Task Create(UserCreateDTO userCreate);
        Task<string> Autonticate(AuthenticateDTO authenticateDTO);
    }
}
