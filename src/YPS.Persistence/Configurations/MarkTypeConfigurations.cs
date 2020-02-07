using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class MarkTypeConfigurations : IEntityTypeConfiguration<MarkType>
    {
        public void Configure(EntityTypeBuilder<MarkType> builder)
        {
            builder.Property(e => e.Type)
                .HasMaxLength(50);

            builder.Property(e => e.Description)
                .HasMaxLength(255);

            builder.HasMany(e => e.Marks)
                .WithOne(e => e.MarkType);
        }
    }
}
