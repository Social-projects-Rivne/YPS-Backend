using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class TeacherToDisciplineConfiguration : IEntityTypeConfiguration<TeacherToDiscipline>
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

            builder.HasData(
                    new TeacherToDiscipline { Id = 1, DisciplineId = 1, TeacherId = 1 },
                    new TeacherToDiscipline { Id = 2, DisciplineId = 2, TeacherId = 4 },
                    new TeacherToDiscipline { Id = 3, DisciplineId = 3, TeacherId = 2 },
                    new TeacherToDiscipline { Id = 4, DisciplineId = 3, TeacherId = 3 }
                );
        }
    }
}
