namespace Application.DTOs.Service
{
    public class ServiceDTO
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Title1 { get; set; }
        public required string Subtitle { get; set; }
        public required string Title2 { get; set; }
        public required string ImageBase64 { get; set; }
        public List<string> ServiceItems { get; set; }

   
        public string? ExtraTitle { get; set; }
        
        public string? ExtraDescription { get; set; }
    }
}
