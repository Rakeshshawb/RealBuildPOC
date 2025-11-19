namespace UserService.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }

        public User(string fullName, string email, string passwordHash)
        {
            FullName = fullName;
            Email = email;
            PasswordHash = passwordHash;
        }
    }
}
