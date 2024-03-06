namespace Application.DTOs.OVerViews
{
    public class OverViewDTO
    {
        public int Id { get; set; }
        public required string ImageBase64 { get; set; }
        public required string Description { get; set; }
    }
}
