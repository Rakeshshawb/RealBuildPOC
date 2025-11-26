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
        public async Task<AdminSellerDtos?> GetAllOrganization(int id)
        {
            var adminSeller = await _repo.GetAllOrganization(id);
            if (adminSeller == null) return null;

            return new AdminSellerDtos
            {
                ID = adminSeller.ID,
                Name = adminSeller.Name,
                Code=adminSeller.Code,
                Description = adminSeller.Description,
                LogoPath = adminSeller.LogoPath,
                PrimaryEmail = adminSeller.PrimaryEmail ,
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
                UpdatedBy= adminSeller.UpdatedBy,
                UpdatedOn = adminSeller.UpdatedOn,
                DeletedBy = adminSeller.DeletedBy,
                DeletedOn = adminSeller.DeletedOn
            };
        }
    }
}
