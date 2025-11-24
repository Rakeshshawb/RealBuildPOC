using Dapper;
using System.Data;
using System.Data.Common;
using AdminSellerService.Application.Interfaces;
using AdminSellerService.Domain.Entities;

namespace AdminSellerService.Infrastructure.Repositories
{
    public class  AdminSellerRepository : IAdminSellerRepository
    {
        private readonly IDbConnection _db;

        //public AdminSeller(IDbConnection db)
        //{
        //    _db = db;
        //}

    }
}
