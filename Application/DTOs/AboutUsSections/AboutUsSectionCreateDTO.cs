using Domain.Common.Enums;

namespace Application.DTOs.AboutUsSections
{
    public class AboutUsSectionCreateDTO
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public AboutUsType Type { get; set; }
        public int Priority { get; set; }
        public string? Title { get; set; }
        public string Description { get; set; }
    }
}
