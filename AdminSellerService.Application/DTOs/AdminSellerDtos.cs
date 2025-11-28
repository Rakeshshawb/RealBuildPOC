namespace AdminSellerService.Application.DTOs
{
    public class AdminSellerDtos
    {
        public long ID { get; set; }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string LogoPath { get; set; }

        public string PrimaryEmail { get; set; }
        public string SecondaryEmail { get; set; }

        public string PrimaryPhone { get; set; }
        public string SecondaryPhone { get; set; }

        public string Website { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public long? FK_CountryID { get; set; }
        public long? FK_StateID { get; set; }
        public long? FK_CityID { get; set; }

        public string ZipCode { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }

        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public long? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
    public class DeleteOrganizationRequest
    {
        public List<long> Ids { get; set; }
        public long DeletedBy { get; set; }
    }

    public class InsertOrganizationRequest  
    {
        public string Name { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public string? LogoPath { get; set; }
        public string? PrimaryEmail { get; set; }
        public string? SecondaryEmail { get; set; }
        public string? PrimaryPhone { get; set; }
        public string? SecondaryPhone { get; set; }
        public string? Website { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public long? FK_CountryID { get; set; }
        public long? FK_StateID { get; set; }
        public long? FK_CityID { get; set; }
        public string? ZipCode { get; set; }


        public bool IsActive { get; set; } = true;


        public long? CreatedBy { get; set; }
    }

    public class UpdateOrganizationRequest
    {
        public long ID { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public string? LogoPath { get; set; }
        public string? PrimaryEmail { get; set; }
        public string? SecondaryEmail { get; set; }
        public string? PrimaryPhone { get; set; }
        public string? SecondaryPhone { get; set; }
        public string? Website { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public long? FK_CountryID { get; set; }
        public long? FK_StateID { get; set; }
        public long? FK_CityID { get; set; }
        public string? ZipCode { get; set; }
        public bool? IsActive { get; set; }
        public long? UpdatedBy { get; set; }
    }

}
