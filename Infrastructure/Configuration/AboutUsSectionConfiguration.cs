using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class AboutUsSectionConfiguration:IEntityTypeConfiguration<AboutUsSection>
    {
        public void Configure(EntityTypeBuilder<AboutUsSection> builder)
        {
            builder.Property(s => s.Title).HasMaxLength(500);
            builder.HasQueryFilter(s => !s.IsDeleted);
        }
    }
}
