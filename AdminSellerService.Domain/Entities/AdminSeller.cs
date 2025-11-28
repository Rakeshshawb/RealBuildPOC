
namespace AdminSellerService.Domain.Entities
{
    public class AdminSeller
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

        // 👇 REQUIRED FOR DAPPER
        public AdminSeller() { }


        // Your custom constructor
        public AdminSeller(long ID, string Name, string Description)
        {
            ID = ID;
            Name = Name;
            Description = Description;
        }
    }
    public class OrganizationDetails
    {
        // Organization
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

        // Business
        public string BankName { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankIFSC { get; set; }
        public string BankMICR { get; set; }
        public string BankBranch { get; set; }
        public string DocumentPath { get; set; }

        // Statutory
        public string GSTNumber { get; set; }
        public string GSTPath { get; set; }
        public string PANNumber { get; set; }
        public string PANPath { get; set; }
        public string TANNumber { get; set; }
        public string TANPath { get; set; }

        // User
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string PasswordHash { get; set; }


        // Child Models (Composition)
        public BusinessDetails BusinessDetails { get; set; }
        public StatutoryDetails StatutoryDetails { get; set; }
        public UserDetails UserDetails { get; set; }

        public OrganizationDetails() { }
    }
    public class BusinessDetails
    {
        public string BankName { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankIFSC { get; set; }
        public string BankMICR { get; set; }
        public string BankBranch { get; set; }
        public string DocumentPath { get; set; }
    }

    public class StatutoryDetails
    {
        public string GSTNumber { get; set; }
        public string GSTPath { get; set; }
        public string PANNumber { get; set; }
        public string PANPath { get; set; }
        public string TANNumber { get; set; }
        public string TANPath { get; set; }
    }

    public class UserDetails
    {
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string PasswordHash { get; set; }
    }
}
