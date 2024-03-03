using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ContactCommentConfiguration:IEntityTypeConfiguration<ContactComment>
    {
        public void Configure(EntityTypeBuilder<ContactComment> builder)
        {
            builder.Property(s => s.FullName).HasMaxLength(80);
            builder.Property(s => s.Email).HasMaxLength(80);
            builder.Property(s => s.Message).HasMaxLength(2000);
        }

    }

}


