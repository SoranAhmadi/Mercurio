using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Service
{
    public class ServiceUpdateDTO 
    {
        public int Id { get; set; }
        [MaxLength(500, ErrorMessage = "عنوان اجباری است و حداکثر طول آن 500 کارکتر است")]
        public required string Title { get; set; }
        [MaxLength(500, ErrorMessage = "عنوان1 اجباری است و حداکثر طول آن 500 کارکتر است")]
        public required string Title1 { get; set; }
        [MaxLength(500, ErrorMessage = "زیر عنوان اجباری است و حداکثر طول آن 500 کارکتر است")]

        public required string Subtitle { get; set; }
        [MaxLength(500, ErrorMessage = "عنوان2 اجباری است و حداکثر طول آن 500 کارکتر است")]

        public required string Title2 { get; set; }
        public required string ImageBase64 { get; set; }

    
        [MaxLength(500, ErrorMessage = "عنوان اضافی اختیاری است و حداکثر طول آن 500 کارکتر است")]
        public string? ExtraTitle { get; set; }
        [MaxLength(500)]
        public string? ExtraDescription { get; set; }
        public List<ServiceItemUpdateDTO> ServiceUpdateItems { get; set; }
    }
}
