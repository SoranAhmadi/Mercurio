namespace Domain.Entities
{
    public class WhyUs:Entity
    {
        public int Priority { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }

    }
}
