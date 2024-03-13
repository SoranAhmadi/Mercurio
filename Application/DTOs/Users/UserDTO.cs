namespace Application.DTOs.Users
{
    public class UserDTO
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string UserName { get; set; }
        public string UserType { get; set; }
        public string? Image { get; set; }
    }
}
