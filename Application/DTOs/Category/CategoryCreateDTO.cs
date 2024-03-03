using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Category
{
    public class CategoryCreateDTO
    {
        [MaxLength(500, ErrorMessage = "عنوان اجباری است و حداکثر طول آن 500 کارکتر است")]
        public required string Title { get; set; }
        public string? Description { get; set; }

    }
}
