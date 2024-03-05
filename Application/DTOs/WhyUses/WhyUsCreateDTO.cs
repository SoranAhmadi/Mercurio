using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.WhyUses
{
    public class WhyUsCreateDTO
    {
        public int Priority { get; set; }
        [MaxLength(200, ErrorMessage = "عنوان اجباری است و حداکثر طول آن 200 کارکتر است")]
        public required string Title { get; set; }
        [MaxLength(2000, ErrorMessage = "توضیحات اجباری است و حداکثر طول آن 2000 کارکتر می باشد.")]
        public required string Description { get; set; }
    }
}
