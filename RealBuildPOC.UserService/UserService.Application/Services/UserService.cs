using UserService.Application.DTOs;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;

namespace UserService.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = await _repo.GetAllUsersAsync();
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email
            });
        }

        public async Task<UserDto?> GetUser(int id)
        {
            var user = await _repo.GetUserByIdAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email
            };
        }

        public async Task<int> CreateUser(string name, string email, string passwordHash)
        {
            var user = new User(name, email, passwordHash);
            return await _repo.CreateUserAsync(user);
        }
    }
}
