using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class ClassToDisciplineConfiguration : IEntityTypeConfiguration<ClassToDiscipline>
    {
        public void Configure(EntityTypeBuilder<ClassToDiscipline> builder)
        {
            builder.HasKey(x => new { x.ClassId, x.DisciplineId });

            builder.HasOne(e => e.Discipline)
                .WithMany(e => e.ClassToDisciplines)
                .HasForeignKey(e => e.DisciplineId)
                .IsRequired();

            builder.HasOne(e => e.Class)
                .WithMany(e => e.ClassToDisciplines)
                .HasForeignKey(e => e.ClassId)
                .IsRequired();

            builder.HasData(
                new ClassToDiscipline() { ClassId = 5, DisciplineId = 1 },
                new ClassToDiscipline() { ClassId = 5, DisciplineId = 2 },
                new ClassToDiscipline() { ClassId = 5, DisciplineId = 3 },
                new ClassToDiscipline() { ClassId = 5, DisciplineId = 4 },
                new ClassToDiscipline() { ClassId = 5, DisciplineId = 5 },
                new ClassToDiscipline() { ClassId = 5, DisciplineId = 6 },
                new ClassToDiscipline() { ClassId = 5, DisciplineId = 7 },
                new ClassToDiscipline() { ClassId = 5, DisciplineId = 8 },
                new ClassToDiscipline() { ClassId = 5, DisciplineId = 9 },
                new ClassToDiscipline() { ClassId = 5, DisciplineId = 10 },
                new ClassToDiscipline() { ClassId = 5, DisciplineId = 11 },
                new ClassToDiscipline() { ClassId = 5, DisciplineId = 12 },
                new ClassToDiscipline() { ClassId = 5, DisciplineId = 13 },
                new ClassToDiscipline() { ClassId = 5, DisciplineId = 14 },
                new ClassToDiscipline() { ClassId = 5, DisciplineId = 15 },
                new ClassToDiscipline() { ClassId = 5, DisciplineId = 16 },
                new ClassToDiscipline() { ClassId = 5, DisciplineId = 17 },
                new ClassToDiscipline() { ClassId = 5, DisciplineId = 18 },
                new ClassToDiscipline() { ClassId = 5, DisciplineId = 19 },
                new ClassToDiscipline() { ClassId = 5, DisciplineId = 20 },
                new ClassToDiscipline() { ClassId = 5, DisciplineId = 21 }
            );
        }
    }
}
