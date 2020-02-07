using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class TeacherToDisciplineConfigurations : IEntityTypeConfiguration<TeacherToDiscipline>
    {
        public void Configure(EntityTypeBuilder<TeacherToDiscipline> builder)
        {
            builder.HasMany(e => e.Lessons)
                .WithOne(e => e.TeacherToDiscipline);

            builder.HasOne(e => e.Discipline)
                .WithMany(e => e.TeacherToDisciplines)
                .HasForeignKey(e => e.DisciplineId);

            builder.HasOne(e => e.Teacher)
                .WithMany(e => e.TeacherToDisciplines)
                .HasForeignKey(e => e.TeacherId);
        }
    }
}
