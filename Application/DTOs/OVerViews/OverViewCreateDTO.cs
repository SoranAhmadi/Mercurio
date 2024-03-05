using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.OVerViews
{
    public class OverViewCreateDTO
    {
        [Required(ErrorMessage = "تصویر اجباری می باشد.")]
        public required string Image { get; set; }
        [Required( ErrorMessage = "توضیحات اجباری می باشد.")]
        public required string Description { get; set; }
    }
}
