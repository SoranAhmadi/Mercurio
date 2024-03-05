using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.ContactUs
{
    public class ContactUsCreateDTO
    {
        [MaxLength(20, ErrorMessage = "شماره تلفن اجباری است طول 20 کاراکتر است ")]
        public required string Phone { get; set; }
        public string? Fax { get; set; }
        public string? Twitter { get; set; }
        public string? WhatsApp { get; set; }
        [MaxLength(500, ErrorMessage = "آدرس  اجباری است طول 500 کاراکتر است ")]
        public required string Address { get; set; }
        [MaxLength(500, ErrorMessage = "آدرس  اجباری است طول 500 کاراکتر است ")]
        public required string Email { get; set; }
        public double Lan { get; set; }
        public double Lat { get; set; }

    }
}
