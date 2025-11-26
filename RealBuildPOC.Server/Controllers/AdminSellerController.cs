using Microsoft.AspNetCore.Mvc;

namespace RealBuildPOC.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminSellerController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminSellerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("GetAllOrganization/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var client = _httpClientFactory.CreateClient("AdminSellerService");
            var response = await client.GetAsync($"api/AdminSeller/GetAllOrganization/{id}");

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();

            return Content(result, "application/json");
        }
    }
}
