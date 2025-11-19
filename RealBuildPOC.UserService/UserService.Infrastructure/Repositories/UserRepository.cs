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
            var sql = "SELECT Id, FullName, Email, PasswordHash FROM Users";
            return await _db.QueryAsync<User>(sql);
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            var sql = "SELECT Id, FullName, Email, PasswordHash FROM Users WHERE Id=@Id";
            return await _db.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
        }

        public async Task<int> CreateUserAsync(User user)
        {
            var sql = @"INSERT INTO Users (FullName, Email, PasswordHash)
                        VALUES (@FullName, @Email, @PasswordHash);
                        SELECT CAST(SCOPE_IDENTITY() as int)";

            var id = await _db.ExecuteScalarAsync<int>(sql, user);
            return id;
        }
    }
}
