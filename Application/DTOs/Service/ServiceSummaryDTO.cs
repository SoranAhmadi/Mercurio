namespace Application.DTOs.Service
{
    public class ServiceSummaryDTO
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public required string ImageBase64 { get; set; }
        public required string Description { get; set; }
    }
}
