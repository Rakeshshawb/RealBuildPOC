using AdminSellerService.Application.DTOs;
using AdminSellerService.Domain.Entities;

namespace AdminSellerService.Application.Interfaces
{
    public interface IAdminSellerService
    {
        Task<IEnumerable<OrganizationDetails>> GetOrganizationDetails(long id);
        Task<int> SoftDeleteOrganizations(IEnumerable<long> ids, long deletedBy);

        Task<int> InsertOrganization(InsertOrganizationRequest request);

        Task<int> UpdateOrganization(UpdateOrganizationRequest request);

    }
}
