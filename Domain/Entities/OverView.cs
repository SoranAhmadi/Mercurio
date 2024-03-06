namespace Domain.Entities
{
    public class OverView:Entity
    {
        public required string ImageBase64 { get; set; }
        public required string Description { get; set; }
    }
}
