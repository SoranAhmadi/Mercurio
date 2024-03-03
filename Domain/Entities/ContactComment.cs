namespace Domain.Entities
{
    public class ContactComment:Entity
    {
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Message { get; set; }
    }
}
