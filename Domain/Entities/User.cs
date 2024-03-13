using Domain.Common.Enums;

namespace Domain.Entities
{
    public class User:Entity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required byte[] Salt { get; set; }
        public UserType UserType { get; set; }
    }
}
