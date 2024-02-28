namespace Application.DTOs.Product
{
    public class ProductCreateDTO
    {
        public required string Title { get; set; }
        public required int CategoryId { get; set; }
        public  string? ImageBase64 { get; set; }
        public string? Description { get; set; }
        public string? Thumbnail { get; set; }
    }
}
