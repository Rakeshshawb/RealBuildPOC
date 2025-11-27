using AdminSellerService.Application.DTOs;
using AdminSellerService.Domain.Entities;

namespace AdminSellerService.Application.Interfaces
{
    public interface IAdminSellerService
    {
        Task<IEnumerable<AdminSeller>> GetAllOrganization(int id);
        Task<int> SoftDeleteOrganizations(IEnumerable<long> ids, long deletedBy);

        Task<int> InsertOrganization(long createdBy);

    }
}
