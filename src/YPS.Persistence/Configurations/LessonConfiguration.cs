﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasMany(e => e.JournalColumns)
                .WithOne(e => e.Lesson);

            builder.HasOne(e => e.TeacherToDiscipline)
                .WithMany(e => e.Lessons)
                .HasForeignKey(e => e.TeacherToDisciplineId);

            builder.HasMany(x => x.Schedules)
                .WithOne(x => x.Lesson);
        }
    }
}