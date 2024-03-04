using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ContactUsConfiguration:IEntityTypeConfiguration<ContactUs>
    {
        public void Configure(EntityTypeBuilder<ContactUs> builder)
        {
            builder.Property(s => s.Phone).HasMaxLength(80);
            builder.Property(s => s.Fax).HasMaxLength(80);
            builder.Property(s => s.Twitter).HasMaxLength(200);
            builder.Property(s => s.WhatsApp).HasMaxLength(200);
            builder.Property(s => s.Address).HasMaxLength(1000);
            builder.Property(s => s.Email).HasMaxLength(200);
        }
    }
}

