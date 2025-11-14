using Microsoft.AspNetCore.Mvc;
using System.Data;
using Dapper;

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
            //var users = await _db.QueryAsync<UserDto>("SELECT * FROM Users");
            //return Ok(users);
            return Ok("");
        }
    }
}
