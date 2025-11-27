using AdminSellerService.Application.DTOs;
using AdminSellerService.Domain.Entities;

namespace AdminSellerService.Application.Interfaces
{

    public interface IAdminSellerRepository
    {
        Task<IEnumerable<AdminSeller>> GetAllOrganization(long id);
        Task<int> SoftDeleteOrganizations(IEnumerable<long> ids, long deletedBy);

        Task<int> InsertOrganization(long createdBy);
    }
}
