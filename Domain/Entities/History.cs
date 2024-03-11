namespace Domain.Entities
{
    public class History(string entity, short action,int UserId) : Entity
    {
        public required string Entity { get; set; } = entity;
        public required short Action { get; set; } = action;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
