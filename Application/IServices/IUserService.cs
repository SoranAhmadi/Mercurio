using Application.DTOs.Users;

namespace Application.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAll();
        Task Create(UserCreateDTO userCreate);
        Task<string> Autonticate(AuthenticateDTO authenticateDTO);
        /*Task Delete(int id);*/
    }
}
