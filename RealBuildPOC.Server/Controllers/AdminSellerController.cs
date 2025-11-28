using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            // Organization
            public string Name { get; set; }
            public string Code { get; set; }
            public string Description { get; set; }
            public string LogoPath { get; set; }
            public string PrimaryEmail { get; set; }
            public string SecondaryEmail { get; set; }
            public string PrimaryPhone { get; set; }
            public string SecondaryPhone { get; set; }
            public string Website { get; set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public long? FK_CountryID { get; set; }
            public long? FK_StateID { get; set; }
            public long? FK_CityID { get; set; }
            public string ZipCode { get; set; }
            public bool IsActive { get; set; } = true;
            public long? CreatedBy { get; set; }

            // Business Details
            public string BankName { get; set; }
            public string BankAccountNumber { get; set; }
            public string BankIFSC { get; set; }
            public string BankMICR { get; set; }
            public string BankBranch { get; set; }
            public string DocumentPath { get; set; }

            // Statutory Details
            public string GSTNumber { get; set; }
            public string GSTPath { get; set; }
            public string PANNumber { get; set; }
            public string PANPath { get; set; }
            public string TANNumber { get; set; }
            public string TANPath { get; set; }

            // User Details
            public string UserEmail { get; set; }
            public string UserPhone { get; set; }
            public string PasswordHash { get; set; }
        }

        public class ClientResponse<T>
        {
            public HttpStatusCode Status { get; set; }
            public string Message { get; set; }
            public T Data { get; set; }
        }


        [HttpPost("InsertOrganization")]
        public async Task<IActionResult> InsertOrganization([FromBody] InsertOrganizationRequest request)
        {
            var clientResponse = new ClientResponse<object>();

            try
            {
                var client = _httpClientFactory.CreateClient("AdminSellerService");

                var response = await client.PostAsJsonAsync(
                    $"api/AdminSeller/InsertOrganization",
                    request
                );

                // Handle non-success status codes
                if (!response.IsSuccessStatusCode)
                {
                    clientResponse.Status = response.StatusCode;
                    clientResponse.Message = "Request failed from AdminSellerService";
                    clientResponse.Data = await response.Content.ReadAsStringAsync();

                    return StatusCode((int)response.StatusCode, clientResponse);
                }

                // Success response
                var res = await response.Content.ReadAsStringAsync();

                clientResponse.Status = HttpStatusCode.OK;
                clientResponse.Message = "Insert successful";
                clientResponse.Data = res;

                return Ok(clientResponse);
            }
            catch (HttpRequestException ex)
            {
                // Could not connect to service
                clientResponse.Status = HttpStatusCode.ServiceUnavailable;
                clientResponse.Message = "AdminSellerService not reachable";
                clientResponse.Data = ex.Message;

                return StatusCode(StatusCodes.Status503ServiceUnavailable, clientResponse);
            }
            catch (TaskCanceledException ex)
            {
                // Timeout
                clientResponse.Status = HttpStatusCode.RequestTimeout;
                clientResponse.Message = "Request timed out";
                clientResponse.Data = ex.Message;

                return StatusCode(StatusCodes.Status408RequestTimeout, clientResponse);
            }
            catch (Exception ex)
            {
                // Any unexpected error
                clientResponse.Status = HttpStatusCode.InternalServerError;
                clientResponse.Message = "Something went wrong";
                clientResponse.Data = ex.Message;

                return StatusCode(StatusCodes.Status500InternalServerError, clientResponse);
            }
        }


        public class UpdateOrganizationRequest
        {
            public long ID { get; set; }
            public string? Name { get; set; }
            public string? Code { get; set; }
            public string? Description { get; set; }
            public string? LogoPath { get; set; }
            public string? PrimaryEmail { get; set; }
            public string? SecondaryEmail { get; set; }
            public string? PrimaryPhone { get; set; }
            public string? SecondaryPhone { get; set; }
            public string? Website { get; set; }
            public string? AddressLine1 { get; set; }
            public string? AddressLine2 { get; set; }
            public long? FK_CountryID { get; set; }
            public long? FK_StateID { get; set; }
            public long? FK_CityID { get; set; }
            public string? ZipCode { get; set; }
            public bool? IsActive { get; set; }
            public long? UpdatedBy { get; set; }
        }


        [HttpPost("UpdateOrganization")]
        public async Task<IActionResult> UpdateOrganization([FromBody] UpdateOrganizationRequest request)
        {
            var clientResponse = new ClientResponse<object>();

            try
            {
                var client = _httpClientFactory.CreateClient("AdminSellerService");

                var response = await client.PostAsJsonAsync(
                    $"api/AdminSeller/UpdateOrganization",
                    request
                );

                // Handle non-success status codes
                if (!response.IsSuccessStatusCode)
                {
                    clientResponse.Status = response.StatusCode;
                    clientResponse.Message = "Request failed from AdminSellerService";
                    clientResponse.Data = await response.Content.ReadAsStringAsync();

                    return StatusCode((int)response.StatusCode, clientResponse);
                }

                // Success response
                var res = await response.Content.ReadAsStringAsync();

                clientResponse.Status = HttpStatusCode.OK;
                clientResponse.Message = "Insert successful";
                clientResponse.Data = res;

                return Ok(clientResponse);
            }
            catch (HttpRequestException ex)
            {
                // Could not connect to service
                clientResponse.Status = HttpStatusCode.ServiceUnavailable;
                clientResponse.Message = "AdminSellerService not reachable";
                clientResponse.Data = ex.Message;

                return StatusCode(StatusCodes.Status503ServiceUnavailable, clientResponse);
            }
            catch (TaskCanceledException ex)
            {
                // Timeout
                clientResponse.Status = HttpStatusCode.RequestTimeout;
                clientResponse.Message = "Request timed out";
                clientResponse.Data = ex.Message;

                return StatusCode(StatusCodes.Status408RequestTimeout, clientResponse);
            }
            catch (Exception ex)
            {
                // Any unexpected error
                clientResponse.Status = HttpStatusCode.InternalServerError;
                clientResponse.Message = "Something went wrong";
                clientResponse.Data = ex.Message;

                return StatusCode(StatusCodes.Status500InternalServerError, clientResponse);
            }
        }

    }
}
