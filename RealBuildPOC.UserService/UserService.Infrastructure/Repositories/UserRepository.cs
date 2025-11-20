using Dapper;
using System.Data;
using System.Data.Common;
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

        //public async Task<IEnumerable<User>> GetAllUsersAsync()
        //{
        //    var sql = "SELECT Id, FullName, Email, PasswordHash FROM [auth].[Users]";
        //    return await _db.QueryAsync<User>(sql);
        //}

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await _db.QueryAsync<User>(
                "[dbo].[sp_GetDummyUsers]",
                commandType: CommandType.StoredProcedure
            );

            return users;
        }

        public async Task<User?> GetUserByIdAsync(long id)
        {
            var user = await _db.QueryFirstOrDefaultAsync<User>(
                "[dbo].[sp_GetDummyUserById]",
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );

            return user;
        }

        public async Task<long> CreateUserAsync(User user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FullName", user.FullName);
            parameters.Add("@Email", user.Email);
            parameters.Add("@PasswordHash", user.PasswordHash);
            parameters.Add("@NewId", dbType: DbType.Int64, direction: ParameterDirection.Output);

            await _db.ExecuteAsync(
                "[dbo].[sp_CreateDummyUser]",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return parameters.Get<long>("@NewId");
        }
    }
}
