using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class CategoryConfiguration:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(s => s.Title).HasMaxLength(500);
            builder.Property(s => s.Code).HasMaxLength(100);
            builder.HasMany(p => p.Products)
                      .WithOne(p => p.Category)
                      .HasForeignKey(p => p.CategoryId)
                      .HasConstraintName("FK_Products_Category");
        }
    }
}
