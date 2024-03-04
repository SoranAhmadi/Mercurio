namespace Domain.Entities
{
    public class Category : Entity
    {
        public required string Title { get; set; }
        public required string ImageBase64 {get;set;}
        public virtual ICollection<Product> Products { get; set; } 
    }
}
