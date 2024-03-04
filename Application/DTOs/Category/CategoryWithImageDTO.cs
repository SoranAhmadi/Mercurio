namespace Application.DTOs.Category
{
    public class CategoryWithImageDTO
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string ImageBase64 { get; set; }
    }
}
