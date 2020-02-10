using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class ScheduleConfigurations : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.Property(e => e.LessonNumber)
                .IsRequired()
                .HasMaxLength(5);

            builder.HasOne(e => e.Lesson)
                .WithMany(e => e.Schedules)
                .HasForeignKey(e => e.LessonId);

            builder.HasOne(e => e.Day)
                .WithMany(e => e.Schedules)
                .HasForeignKey(e => e.DayId); //In context without this line
        }
    }
}
