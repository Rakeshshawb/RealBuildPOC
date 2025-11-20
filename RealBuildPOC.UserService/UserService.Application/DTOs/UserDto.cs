namespace UserService.Application.DTOs
{
    public class UserDto
    {
        public long Id { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
    }
}
