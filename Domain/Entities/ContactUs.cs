namespace Domain.Entities
{
    public class ContactUs : Entity
    {
        public required string Phone { get; set; }
        public string? Fax { get; set; }
        public string? Twitter { get; set; }
        public string? WhatsApp { get; set; }
        public required string Address { get; set; }
        public required string Email { get; set; }
        public double Lan { get; set; }
        public double Lat { get; set; }

    }
}
