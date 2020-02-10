using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class ClassConfigurations : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.Property(e => e.Number)
                .HasMaxLength(3);

            builder.Property(e => e.Character)
                .IsRequired()
                .HasMaxLength(3);

            builder.HasOne(x => x.TeacherOf)
                .WithMany(x => x.Classes)
                .HasForeignKey(x => x.ClassTeacherId);

            builder.HasData(new Class { Id = 1, Number = 1, Character = "a", ClassTeacherId = 2 },
                new Class { Id = 2, Number = 3, Character = "c", ClassTeacherId = 1 },
                new Class { Id = 3, Number = 11, Character = "b", ClassTeacherId = 3 },
                new Class { Id = 4, Number = 9, Character = "1", ClassTeacherId = 4 });
        }
    }
}
