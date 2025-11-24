using AdminSellerService.Application.DTOs;
using AdminSellerService.Application.Interfaces;
using AdminSellerService.Domain.Entities;


namespace AdminSellerService.Application.Services
{
    public class AdminSellerService : IAdminSellerService   
    {
        private readonly IAdminSellerRepository _repo;
    }
}
