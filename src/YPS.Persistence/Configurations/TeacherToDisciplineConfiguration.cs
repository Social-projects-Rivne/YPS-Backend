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
            builder.HasKey(x => new { x.DisciplineId, x.TeacherId });

            builder.HasOne(e => e.Discipline)
                .WithMany(e => e.TeacherToDisciplines)
                .HasForeignKey(e => e.DisciplineId);

            builder.HasOne(e => e.Teacher)
                .WithMany(e => e.TeacherToDisciplines)
                .HasForeignKey(e => e.TeacherId);

            builder.HasData(
                new TeacherToDiscipline { DisciplineId = 1, TeacherId = 1 },
                new TeacherToDiscipline { DisciplineId = 2, TeacherId = 2 },
                new TeacherToDiscipline { DisciplineId = 3, TeacherId = 1 },
                new TeacherToDiscipline { DisciplineId = 4, TeacherId = 3 },
                new TeacherToDiscipline { DisciplineId = 5, TeacherId = 2 },
                new TeacherToDiscipline { DisciplineId = 6, TeacherId = 4 },
                new TeacherToDiscipline { DisciplineId = 7, TeacherId = 1 },
                new TeacherToDiscipline { DisciplineId = 8, TeacherId = 2 },
                new TeacherToDiscipline { DisciplineId = 9, TeacherId = 3 },
                new TeacherToDiscipline { DisciplineId = 10, TeacherId = 4 },
                new TeacherToDiscipline { DisciplineId = 11, TeacherId = 42 },
                new TeacherToDiscipline { DisciplineId = 12, TeacherId = 43 },
                new TeacherToDiscipline { DisciplineId = 13, TeacherId = 44 },
                new TeacherToDiscipline { DisciplineId = 14, TeacherId = 45 },
                new TeacherToDiscipline { DisciplineId = 15, TeacherId = 42 },
                new TeacherToDiscipline { DisciplineId = 16, TeacherId = 44 },
                new TeacherToDiscipline { DisciplineId = 17, TeacherId = 42 },
                new TeacherToDiscipline { DisciplineId = 18, TeacherId = 45 },
                new TeacherToDiscipline { DisciplineId = 2, TeacherId = 3 },
                new TeacherToDiscipline { DisciplineId = 4, TeacherId = 4 },
                new TeacherToDiscipline { DisciplineId = 8, TeacherId = 1 },
                new TeacherToDiscipline { DisciplineId = 12, TeacherId = 44 },
                new TeacherToDiscipline { DisciplineId = 16, TeacherId = 45 }
            );
        }
    }
}
