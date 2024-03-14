using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class OverViewConfiguration : IEntityTypeConfiguration<OverView>
    {
        public void Configure(EntityTypeBuilder<OverView> builder)
        {
            builder.HasQueryFilter(s => !s.IsDeleted);
        }
    }
}
