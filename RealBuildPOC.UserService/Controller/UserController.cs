using Microsoft.AspNetCore.Mvc;
using System.Data;
using Dapper;
using RealBuildPOC.Shared.DTOs;

namespace RealBuildPOC.UserService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDbConnection _db;

        public UserController(IDbConnection db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _db.QueryAsync<UserDto>("SELECT * FROM [auth].[Users]");
            return Ok(users); 
        }
    }
}
