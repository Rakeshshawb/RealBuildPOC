using Microsoft.AspNetCore.Mvc;



namespace RealBuildPOC.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserGatewayController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserGatewayController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var client = _httpClientFactory.CreateClient("UserService");
            var response = await client.GetAsync($"api/user/{id}");

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();

            return Content(result, "application/json");
        }
    }

}
