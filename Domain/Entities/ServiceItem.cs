using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class ServiceItem : Entity
    {
    
        public required string Title { get; set; }
        public int ServiceId { get; set; }
      
        public virtual Service Service { get; set; }
    }
}
