using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class WhyUsConfiguration:IEntityTypeConfiguration<WhyUs>
    {
        public void Configure(EntityTypeBuilder<WhyUs> builder)
        {
            builder.Property(s => s.Title).HasMaxLength(200);
            builder.Property(s => s.Description).HasMaxLength(2000);

        }
    }
}
