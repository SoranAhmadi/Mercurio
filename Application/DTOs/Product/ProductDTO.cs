namespace Application.DTOs.Product
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public required int CategoryId { get; set; }
        public required string Title { get; set; }
        public required string ImageBase64 { get; set; }
        public string? Description { get; set; }
    }
}
