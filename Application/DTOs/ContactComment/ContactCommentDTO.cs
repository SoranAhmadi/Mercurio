namespace Application.DTOs.ContactComment
{
    public class ContactCommentDTO
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Message { get; set; }
    }
}
