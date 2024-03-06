using Domain.Common.Enums;

namespace Domain.Entities
{
    public class AboutUsSection:Entity
    {
        public AboutUsType Type { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Description2 { get; set; }
        public string? Description3 { get; set; }
    }
}
