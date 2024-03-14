namespace Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } 
        public DateTime CreateDate { get; set; }  = DateTime.Now;
        public int? UserId { get; set; }
        
    }
}
