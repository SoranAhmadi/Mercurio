using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Product
{
    public class ProductCreateDTO
    {
        [MaxLength(200, ErrorMessage = "عنوان اجباری است و حداکثر طول آن 200 کارکتر است")]
        public required string Title { get; set; }
        public required int CategoryId { get; set; }
        public  string? ImageBase64 { get; set; }
        public string? Description { get; set; }
        public string? Thumbnail { get; set; }
    }
}
