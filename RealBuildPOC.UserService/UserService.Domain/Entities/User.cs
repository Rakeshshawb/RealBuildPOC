namespace UserService.Domain.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        // 👇 REQUIRED FOR DAPPER
        public User() { }


        // Your custom constructor
        public User(string fullName, string email, string passwordHash)
        {
            FullName = fullName;
            Email = email;
            PasswordHash = passwordHash;
        }
    }
}
