using Dapper;
using System.Data;
using System.Data.Common;
using OrderService.Application.Interfaces;
using OrderService.Domain.Entities;


namespace OrderService.Infrastructure.Repositories
{
    public class OrderRepository :IOrderRepository
    {
        private readonly IDbConnection _db;

        public OrderRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}
