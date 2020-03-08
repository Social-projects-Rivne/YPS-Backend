using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.Property(e => e.LessonDate)
               .IsRequired();

            builder.Property(e => e.LessonNumber)
               .IsRequired();

            builder.Property(e => e.LessonTimeGap)
               .IsRequired();

            builder.HasOne(e => e.Teacher)
                .WithMany(e => e.Lessons)
                .HasForeignKey(e => e.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Class)
                .WithMany(e => e.Lessons)
                .HasForeignKey(e => e.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Discipline)
                .WithMany(e => e.Lessons)
                .HasForeignKey(e => e.DisciplineId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.JournalColumn)
                .WithOne(e => e.Lesson);

            builder.HasOne(e => e.Auditorium)
                .WithMany(e => e.Lessons)
                .HasForeignKey(e => e.AuditoriumId);
        }
    }
}
