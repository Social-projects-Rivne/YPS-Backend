using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class JournalColumnsConfigurations : IEntityTypeConfiguration<JournalColumn>
    {
        public void Configure(EntityTypeBuilder<JournalColumn> builder)
        {
            //builder.Property(e => e.LessonDate)
            //    .HasColumnType("datetime");

            builder.Property(e => e.Theme)
                .HasMaxLength(255);

            builder.HasMany(e => e.Marks)
                .WithOne(e => e.JournalColumn);

            builder.HasOne(e => e.Lesson)
                .WithMany(e => e.JournalColumns)
                .HasForeignKey(e => e.LessonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Homework)
                .WithMany(e => e.JournalColumns)
                .HasForeignKey(e => e.HomeworkId)
                .OnDelete(DeleteBehavior.Restrict);
                

            builder.HasOne(e => e.Journal)
                .WithMany(e => e.JournalColumns)
                .HasForeignKey(e => e.JournalId);



        }
    }
}
