using UserService.Application.DTOs;

namespace UserService.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<UserDto?> GetUser(int id);
        Task<long> CreateUser(string name, string email, string passwordHash);
    }
}
