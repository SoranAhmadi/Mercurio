using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.OVerViews
{
    public class OverViewUpdateDTO
    {
        public int Id { get; set; }
        public  string? ImageBase64 { get; set; }
        [Required(ErrorMessage = "توضیحات اجباری می باشد.")]
        public required string Description { get; set; }

    }
}
