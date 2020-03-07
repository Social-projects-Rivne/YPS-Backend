using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class JournalColumnConfiguration : IEntityTypeConfiguration<JournalColumn>
    {
        public void Configure(EntityTypeBuilder<JournalColumn> builder)
        {
            builder.Property(e => e.Topic)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(e => e.Marks)
                .WithOne(e => e.JournalColumn)
                .HasForeignKey(e => e.JournalColumnId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Lesson)
                .WithOne(e => e.JournalColumn)
                .HasForeignKey<JournalColumn>(e => e.LessonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Homework)
                .WithOne(e => e.JournalColumn)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Journal)
                .WithMany(e => e.JournalColumns)
                .HasForeignKey(e => e.JournalId);
        }
    }
}
