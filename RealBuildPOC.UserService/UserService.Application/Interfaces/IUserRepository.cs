using UserService.Domain.Entities;

namespace UserService.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(long id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<long> CreateUserAsync(User user);
    }
}
