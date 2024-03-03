namespace Application.DTOs.ContactComment
{
    public class ContactCommentCreateDTO
    {
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Message { get; set; }
    }
}
