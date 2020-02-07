using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class HomeworkConfigurations : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.Property(e => e.Title)
                .HasMaxLength(255);

            builder.HasOne(e => e.Mark)
                .WithMany(e => e.Homeworks)
                .HasForeignKey(e => e.MarkId);

            builder.HasMany(e => e.JournalColumns)
                .WithOne(e => e.Homework);
        }
    }
}
