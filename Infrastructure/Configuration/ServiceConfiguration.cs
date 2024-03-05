using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(s => s.Title).HasMaxLength(500);
            builder.Property(s=>s.Title1).HasMaxLength(500);
            builder.Property(s=>s.Subtitle).HasMaxLength(500);
            builder.Property(s=>s.Title2).HasMaxLength(500);
            builder.Property(s=>s.ExtraTitle).HasMaxLength(500);
            builder.Property(s => s.ExtraDescription).HasMaxLength(500);
            builder.Property(s => s.Description).HasMaxLength(2000);
            builder.HasMany(p => p.ServiceItems)
                  .WithOne(p => p.Service)
                  .HasForeignKey(p => p.ServiceId)
                  .HasConstraintName("FK_ServiceItems_Service");
        }
    }
}
