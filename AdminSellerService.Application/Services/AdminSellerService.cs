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
        public async Task<IEnumerable<OrganizationDetails>> GetOrganizationDetails(long id)
        {

            var rows = await _repo.GetOrganizationDetails(id);

            return rows.Select(r => new OrganizationDetails
            {
                ID = r.ID,
                Name = r.Name,
                Code = r.Code,
                Description = r.Description,
                LogoPath = r.LogoPath,

                PrimaryEmail = r.PrimaryEmail,
                SecondaryEmail = r.SecondaryEmail,

                PrimaryPhone = r.PrimaryPhone,
                SecondaryPhone = r.SecondaryPhone,

                Website = r.Website,
                AddressLine1 = r.AddressLine1,
                AddressLine2 = r.AddressLine2,

                FK_CountryID = r.FK_CountryID,
                FK_StateID = r.FK_StateID,
                FK_CityID = r.FK_CityID,
                ZipCode = r.ZipCode,

                IsActive = r.IsActive,
                IsDeleted = r.IsDeleted,

                CreatedBy = r.CreatedBy,
                CreatedOn = r.CreatedOn,
                UpdatedBy = r.UpdatedBy,
                UpdatedOn = r.UpdatedOn,
                DeletedBy = r.DeletedBy,
                DeletedOn = r.DeletedOn,

                // New composed models
                BusinessDetails = new BusinessDetails
                {
                    BankName = r.BankName,
                    BankAccountNumber = r.BankAccountNumber,
                    BankIFSC = r.BankIFSC,
                    BankMICR = r.BankMICR,
                    BankBranch = r.BankBranch,
                    DocumentPath = r.DocumentPath
                },

                StatutoryDetails = new StatutoryDetails
                {
                    GSTNumber = r.GSTNumber,
                    GSTPath = r.GSTPath,
                    PANNumber = r.PANNumber,
                    PANPath = r.PANPath,
                    TANNumber = r.TANNumber,
                    TANPath = r.TANPath
                },

                UserDetails = new UserDetails
                {
                    UserEmail = r.UserEmail,
                    UserPhone = r.UserPhone,
                    PasswordHash = r.PasswordHash
                }
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
