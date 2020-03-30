using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class MarkTypeConfiguration : IEntityTypeConfiguration<MarkType>
    {
        public void Configure(EntityTypeBuilder<MarkType> builder)
        {
            builder.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(e => e.Marks)
                .WithOne(e => e.MarkType);

            builder.HasData(
                new MarkType()
                {
                    Id = 1,
                    Type = "classwork",
                    Description = "You can get this mark by working hardly at lesson"
                },
                new MarkType()
                {
                    Id = 2,
                    Type = "homework",
                    Description = "You can get this mark by doing your homework"
                },
                new MarkType()
                {
                    Id = 3,
                    Type = "test",
                    Description = "You can get this mark by finishing your tets"
                });
        }
    }
}
