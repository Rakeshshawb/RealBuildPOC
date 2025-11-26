using Microsoft.AspNetCore.Mvc;
using AdminSellerService.Application.Interfaces;
using AdminSellerService.Application.DTOs;

namespace AdminSellerService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminSellerController : ControllerBase
    {
        private readonly IAdminSellerService _service;

        public AdminSellerController(IAdminSellerService service)
        {
            _service = service;
        }


        [HttpGet("GetAllOrganization/{id}")]
        public async Task<IActionResult> GetAllOrganization(int id)
        {
            var adminseller = await _service.GetAllOrganization(id);
            if (adminseller == null) return NotFound();
            return Ok(adminseller);
        }


        [HttpPost("DeleteOrganization")]
        public async Task<IActionResult> SoftDelete([FromBody] DeleteOrganizationRequest request)
        {
            var result = await _service.SoftDeleteOrganizations(request.Ids, request.DeletedBy);
            if (result == 0) return NotFound();
            return Ok("Deleted successfully");
        }
    }
}
