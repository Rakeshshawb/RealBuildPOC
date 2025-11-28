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
        // Organization
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
        public bool IsActive { get; set; } = true;
        public long? CreatedBy { get; set; }

        // Business Details
        public string BankName { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankIFSC { get; set; }
        public string BankMICR { get; set; }
        public string BankBranch { get; set; }
        public string DocumentPath { get; set; }

        // Statutory Details
        public string GSTNumber { get; set; }
        public string GSTPath { get; set; }
        public string PANNumber { get; set; }
        public string PANPath { get; set; }
        public string TANNumber { get; set; }
        public string TANPath { get; set; }

        // User Details
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string PasswordHash { get; set; }
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
