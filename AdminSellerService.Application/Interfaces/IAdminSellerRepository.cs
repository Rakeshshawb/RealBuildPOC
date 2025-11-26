using AdminSellerService.Application.DTOs;
using AdminSellerService.Domain.Entities;

namespace AdminSellerService.Application.Interfaces
{
    
    public interface IAdminSellerRepository
    {
        Task<AdminSeller?> GetAllOrganization(long id);
    }
}
