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

        public async Task<int> InsertOrganization(long createdBy)
        {
            try
            {
                //var idString = string.Join(",", ids);

                var result = await _db.ExecuteAsync(
                    "[organization].[sp_InsertOrganization]",
                    //new { Ids = idString, DeletedBy = createdBy },
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

    }
}
