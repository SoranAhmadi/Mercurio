namespace Application.DTOs.WhyUses
{
    public class WhyUsCreateDTO
    {
        public int Priority { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
    }
}
