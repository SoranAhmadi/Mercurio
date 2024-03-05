namespace Application.DTOs.ContactUs
{
    public class ContactUsDTO
    {
        public int Id { get; set; }
        public required string Phone { get; set; }
        public string? Fax { get; set; }
        public string? Twitter { get; set; }
        public string? WhatsApp { get; set; }
        public required string Address { get; set; }
        public required string Email { get; set; }
        public decimal Lan { get; set; }
        public decimal Lat { get; set; }

    }
}
