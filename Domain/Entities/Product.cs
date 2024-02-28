namespace Domain.Entities
{
    public class Product:Entity
    {
        public required string Title { get; set; }
        public required int CategoryId { get; set; }
        public required string ImageBase64 { get; set; }
        public string? Thumbnail { get; set; }
        public string? Description { get; set; }
        public virtual Category Category { get; set; }

    }
}
