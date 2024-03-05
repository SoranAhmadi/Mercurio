namespace Application.DTOs.WhyUses
{
    public class WhyUsUpdateDTO
    {
        public int Id { get; set; }
        public int Priority { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
    }
}
