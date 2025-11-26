using AdminSellerService.Application.DTOs;

namespace AdminSellerService.Application.Interfaces
{
    public interface IAdminSellerService
    {
        Task<AdminSellerDtos?> GetAllOrganization(int id);
    }
}
