using Domain.Common.Enums;

namespace Application.DTOs.AboutUsSections
{
    public class AboutUsSectionCreateDTO
    {
        
        public AboutUsType Type { get; set; }
        public string? Title { get; set; }
        public string Description { get; set; }
        public string? Description2 { get; set; }
        public string? Description3 { get; set;}
    }
}
