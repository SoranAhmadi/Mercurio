using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Service:Entity
    {
      
        public required string Title { get; set; }
      
        public required string Title1 { get; set; }
  
        public required string Subtitle {  get; set; }
      
        public required string Title2 { get; set; }
       
        public string? ExtraTitle { get; set; }
      
        public string? ExtraDescription { get; set; }

        public required string ImageBase64 { get; set; }
        public virtual ICollection<ServiceItem> ServiceItems { get; set; }       
    }
}
