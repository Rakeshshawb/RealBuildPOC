using UserService.Application.DTOs;

namespace UserService.Application.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<UserDto?> GetUser(int id);
        Task<int> CreateUser(string name, string email, string passwordHash);
    }
}
