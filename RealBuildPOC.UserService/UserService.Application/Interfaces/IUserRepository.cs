using UserService.Domain.Entities;

namespace UserService.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<int> CreateUserAsync(User user);
    }
}
