using Dapper;
using System.Data;
using AdminSellerService.Application.Interfaces;
using AdminSellerService.Domain.Entities;
using AdminSellerService.Application.DTOs;

namespace AdminSellerService.Infrastructure.Repositories
{
    public class AdminSellerRepository : IAdminSellerRepository
    {
        private readonly IDbConnection _db;
        public AdminSellerRepository(IDbConnection db)
        {
            _db = db;
        }


        public async Task<IEnumerable<AdminSeller>> GetAllOrganization(long id)
        {
            var AdminSeller = await _db.QueryAsync<AdminSeller>(
                "[organization].[sp_GetOrganizations]",
               new { ID = id == 0 ? (long?)null : id },
                commandType: CommandType.StoredProcedure
            );

            return AdminSeller;
        }

        public async Task<int> SoftDeleteOrganizations(IEnumerable<long> ids, long deletedBy)
        {
            try
            {
                var idString = string.Join(",", ids);

                var result = await _db.ExecuteAsync(
                    "[organization].[sp_DeleteOrganization]",
                    new { Ids = idString, DeletedBy = deletedBy },
                    commandType: CommandType.StoredProcedure
                );

                return result; // number of rows affected
            }
            catch (Exception ex)
            {
                // Any other unexpected errors
                throw new Exception($"Unexpected error occurred while deleting organizations: {ex.Message}", ex);
            }
        }

        public async Task<int> InsertOrganization(InsertOrganizationRequest request)
        {
            try
            {
                // Map DTO properties to stored-proc parameters (Dapper will match by name)
                var parameters = new
                {
                    Name = request.Name,
                    Code = request.Code,
                    Description = request.Description,
                    LogoPath = request.LogoPath,
                    PrimaryEmail = request.PrimaryEmail,
                    SecondaryEmail = request.SecondaryEmail,
                    PrimaryPhone = request.PrimaryPhone,
                    SecondaryPhone = request.SecondaryPhone,
                    Website = request.Website,
                    AddressLine1 = request.AddressLine1,
                    AddressLine2 = request.AddressLine2,
                    FK_CountryID = request.FK_CountryID,
                    FK_StateID = request.FK_StateID,
                    FK_CityID = request.FK_CityID,
                    ZipCode = request.ZipCode,
                    IsActive = request.IsActive,
                    CreatedBy = request.CreatedBy
                };

                var result = await _db.ExecuteAsync(
                    "[organization].[sp_InsertOrganization]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result; // number of rows affected
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error occurred while inserting organization: {ex.Message}", ex);
            }
        }

        public async Task<int> UpdateOrganization(UpdateOrganizationRequest request)
        {
            try
            {
                // Map DTO properties to stored-proc parameters (Dapper will match by name)
                var parameters = new
                {
                    ID = request.ID,
                    Name = request.Name,
                    Code = request.Code,
                    Description = request.Description,
                    LogoPath = request.LogoPath,
                    PrimaryEmail = request.PrimaryEmail,
                    SecondaryEmail = request.SecondaryEmail,
                    PrimaryPhone = request.PrimaryPhone,
                    SecondaryPhone = request.SecondaryPhone,
                    Website = request.Website,
                    AddressLine1 = request.AddressLine1,
                    AddressLine2 = request.AddressLine2,
                    FK_CountryID = request.FK_CountryID,
                    FK_StateID = request.FK_StateID,
                    FK_CityID = request.FK_CityID,
                    ZipCode = request.ZipCode,
                    IsActive = request.IsActive,
                    UpdatedBy = request.UpdatedBy
                };

                var result = await _db.ExecuteAsync(
                    "[organization].[sp_UpdateOrganization]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result; // number of rows affected
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error occurred while updating organization: {ex.Message}", ex);
            }
        }

    }
}
