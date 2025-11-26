using Dapper;
using System.Data;
using System.Data.Common;
using AdminSellerService.Application.Interfaces;
using AdminSellerService.Domain.Entities;
using AdminSellerService.Application.DTOs;

namespace AdminSellerService.Infrastructure.Repositories
{
    public class  AdminSellerRepository : IAdminSellerRepository
    {
        private readonly IDbConnection _db;
        public AdminSellerRepository(IDbConnection db)
        {
            _db = db;
        }


        public async Task<AdminSeller?> GetAllOrganization(long id)
        {
            var AdminSeller = await _db.QueryFirstOrDefaultAsync<AdminSeller>(
                "[organization].[sp_GetOrganizations]",
                new { ID = id },
                commandType: CommandType.StoredProcedure
            );

            return AdminSeller;
        }

    }
}
