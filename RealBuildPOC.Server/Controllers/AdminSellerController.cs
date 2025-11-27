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
        public class DeleteOrganizationRequest
        {
            public List<long> Ids { get; set; }
            public long DeletedBy { get; set; }
        }
        [HttpPost("DeleteOrganization")]
        public async Task<IActionResult> SoftDelete([FromBody] DeleteOrganizationRequest request)
        {
            var client = _httpClientFactory.CreateClient("AdminSellerService");

            var response = await client.PostAsJsonAsync(
                $"api/AdminSeller/DeleteOrganization",
                request
            );

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();

            return Content(result, "application/json");
        }


        public class InsertOrganizationRequest
        {
            public List<long> Ids { get; set; }
            public long DeletedBy { get; set; }
        }

        [HttpPost("InsertOrganization")]
        public async Task<IActionResult> InsertOrganization([FromBody] InsertOrganizationRequest request)
        {
            var client = _httpClientFactory.CreateClient("AdminSellerService");

            var response = await client.PostAsJsonAsync(
                $"api/AdminSeller/InsertOrganization",
                request
            );

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();

            return Content(result, "application/json");
        }


    }
}
