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

        [HttpGet("get-all")]
        public IActionResult GetUsers()
        {
            return Ok(new { Message = "User service is working!" });
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            var users = await _db.QueryAsync<UserDto>("SELECT * FROM [auth].[Users]");
            return Ok(users);
        }

        [HttpGet("GetCities/{ID}")]
        public async Task<IActionResult> GetCities(long ID)
        {
            try {
                var parameters = new DynamicParameters();
                parameters.Add("@ID", ID);

                var cities = await _db.QueryAsync<CityDto>(
                 "[lookup].[getCities]",  // SP name
                  parameters,//new { ID=ID },//cann also be added like this
                 commandType: CommandType.StoredProcedure
                );
                if (cities == null || !cities.Any())
                {
                    return NotFound(new { status = 404, message = "No cities found for the given ID." });
                }

                return Ok(new
                {
                    status = 200,
                    message = "Success",
                    data = cities
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    status = 500,
                    message = "Internal server error",
                    error = ex.Message
                });
            }
            
        }
    }
}
