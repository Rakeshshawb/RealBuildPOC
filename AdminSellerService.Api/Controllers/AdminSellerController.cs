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

        [HttpPost("InsertOrganization")]
        public async Task<IActionResult> Insert([FromBody] InsertOrganizationRequest request)
        {
            var result = await _service.InsertOrganization(request);

            if (result == 0)
                return BadRequest("Insert failed");

            return Ok("Inserted successfully");
        }


        [HttpPost("UpdateOrganization")]
        public async Task<IActionResult> Update([FromBody] InsertOrganizationRequest request)
        {
            var result = await _service.InsertOrganization(request);

            if (result == 0)
                return BadRequest("Update failed");

            return Ok("Updated successfully");
        }
    }
}
