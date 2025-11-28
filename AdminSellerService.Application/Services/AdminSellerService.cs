using AdminSellerService.Application.DTOs;
using AdminSellerService.Application.Interfaces;
using AdminSellerService.Domain.Entities;


namespace AdminSellerService.Application.Services
{
    public class AdminSellerService : IAdminSellerService
    {
        private readonly IAdminSellerRepository _repo;

        public AdminSellerService(IAdminSellerRepository repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<AdminSeller>> GetAllOrganization(int id)
        {

            var adminSeller = await _repo.GetAllOrganization(id);

            return adminSeller.Select(adminSeller => new AdminSeller
            {
                ID = adminSeller.ID,
                Name = adminSeller.Name,
                Code = adminSeller.Code,
                Description = adminSeller.Description,
                LogoPath = adminSeller.LogoPath,
                PrimaryEmail = adminSeller.PrimaryEmail,
                SecondaryEmail = adminSeller.SecondaryEmail,
                PrimaryPhone = adminSeller.PrimaryPhone,
                SecondaryPhone = adminSeller.SecondaryPhone,
                Website = adminSeller.Website,
                AddressLine1 = adminSeller.AddressLine1,
                AddressLine2 = adminSeller.AddressLine2,
                FK_CountryID = adminSeller.FK_CountryID,
                FK_StateID = adminSeller.FK_StateID,
                FK_CityID = adminSeller.FK_CityID,
                ZipCode = adminSeller.ZipCode,
                IsActive = adminSeller.IsActive,
                IsDeleted = adminSeller.IsDeleted,
                CreatedBy = adminSeller.CreatedBy,
                CreatedOn = adminSeller.CreatedOn,
                UpdatedBy = adminSeller.UpdatedBy,
                UpdatedOn = adminSeller.UpdatedOn,
                DeletedBy = adminSeller.DeletedBy,
                DeletedOn = adminSeller.DeletedOn
            });
        }

        public async Task<int> SoftDeleteOrganizations(IEnumerable<long> ids, long deletedBy)
        {
            var result = await _repo.SoftDeleteOrganizations(ids, deletedBy);

            return result;
        }


        public async Task<int> InsertOrganization(InsertOrganizationRequest request)
        {
            // Call repository to insert data
            var result = await _repo.InsertOrganization(request);

            return result; // return inserted row count or new ID
        }


        public async Task<int> UpdateOrganization(UpdateOrganizationRequest request)
        {
            // Call repository to insert data
            var result = await _repo.UpdateOrganization(request);

            return result; // return inserted row count or new ID
        }
    }
}
