namespace Application.DTOs.Product
{
    public class ProductSearchViewDTO
    {
        public int Id { get; set; }
        public required int CategoryId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? Thumbnail { get; set; }

    }
}
