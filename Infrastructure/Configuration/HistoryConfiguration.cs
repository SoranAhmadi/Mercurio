using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class HistoryConfiguration:IEntityTypeConfiguration<History>
    {
        public void Configure(EntityTypeBuilder<History> builder)
        {
            builder.Property(s => s.Entity).HasMaxLength(80);
            builder.HasQueryFilter(s => !s.IsDeleted);
        }
    }

}
