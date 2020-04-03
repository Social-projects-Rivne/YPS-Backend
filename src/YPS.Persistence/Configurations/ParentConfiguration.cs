using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class ParentConfiguration : IEntityTypeConfiguration<Parent>
    {
        public void Configure(EntityTypeBuilder<Parent> builder)
        {
            builder.Property(e => e.WorkInfo)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(e => e.ParentToPupils)
                .WithOne(e => e.ParentOf);

            builder.HasOne(e => e.User)
                .WithOne(e => e.Parent)
                .HasForeignKey<Parent>(e => e.Id);

            builder.HasData(
                new Parent { Id = 5, WorkInfo = "Software Developer in SoftServe" },
                new Parent { Id = 6, WorkInfo = "WorkInfo parent2" },
                new Parent { Id = 7, WorkInfo = "WorkInfo parent3" },
                new Parent { Id = 8, WorkInfo = "WorkInfo parent4" },
                new Parent { Id = 9, WorkInfo = "WorkInfo parent5" },
                new Parent { Id = 10, WorkInfo = "WorkInfo parent6" },
                new Parent { Id = 11, WorkInfo = "WorkInfo parent7" },
                new Parent { Id = 12, WorkInfo = "WorkInfo parent8" },
                new Parent { Id = 13, WorkInfo = "WorkInfo parent9" },
                new Parent { Id = 14, WorkInfo = "WorkInfo parent10" },
                new Parent { Id = 46, WorkInfo = "Software developer"}
            );
        }
    }
}
