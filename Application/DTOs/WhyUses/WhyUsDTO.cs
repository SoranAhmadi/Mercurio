namespace Application.DTOs.WhyUses
{
    public class WhyUsDTO
    {
        public int Id { get; set; }
        public int Priority { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }

    }
}
