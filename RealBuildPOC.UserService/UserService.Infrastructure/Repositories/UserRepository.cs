using Dapper;
using System.Data;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;

namespace UserService.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _db;

        public UserRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            string sql = "SELECT * FROM Users";
            return await _db.QueryAsync<User>(sql);
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            string sql = "SELECT * FROM Users WHERE Id = @Id";
            return (await _db.QueryAsync<User>(sql, new { Id = id })).FirstOrDefault();
        }

        public async Task<int> CreateUserAsync(User user)
        {
            string sql = @"INSERT INTO Users (FullName, Email, PasswordHash)
                           VALUES (@FullName, @Email, @PasswordHash);
                           SELECT CAST(SCOPE_IDENTITY() as int)";
            return await _db.ExecuteScalarAsync<int>(sql, user);
        }
    }
}
