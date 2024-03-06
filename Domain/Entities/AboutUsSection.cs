using Domain.Common.Enums;

namespace Domain.Entities
{
    public class AboutUsSection:Entity
    {
        public int Row { get; set; }
        public AboutUsType Type { get; set; }
        public int Priority { get; set; }
        public string? Title { get; set; }
        public string Description { get; set; }
    }
}
