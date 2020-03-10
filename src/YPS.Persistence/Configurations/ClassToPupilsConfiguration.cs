using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class ClassToPupilsConfiguration : IEntityTypeConfiguration<ClassToPupil>
    {
        public void Configure(EntityTypeBuilder<ClassToPupil> builder)
        {
            builder.HasKey(x => new { x.ClassId, x.PupilId });

            builder.HasOne(e => e.Pupil)
                .WithMany(e => e.ClassToPupils)
                .HasForeignKey(e => e.PupilId)
                .IsRequired();

            builder.HasOne(e => e.Class)
                .WithMany(e => e.ClassToPupils)
                .HasForeignKey(e => e.ClassId)
                .IsRequired();

            builder.HasData(
                new ClassToPupil
                {
                    ClassId = 1,
                    PupilId = 15
                },
                new ClassToPupil
                {
                    ClassId = 1,
                    PupilId = 16
                },
                new ClassToPupil
                {
                    ClassId = 1,
                    PupilId = 17
                },
                new ClassToPupil
                {
                    ClassId = 2,
                    PupilId = 18
                },
                new ClassToPupil
                {
                    ClassId = 2,
                    PupilId = 19
                },
                new ClassToPupil
                {
                    ClassId = 3,
                    PupilId = 20
                },
                new ClassToPupil
                {
                    ClassId = 3,
                    PupilId = 21
                },
                new ClassToPupil
                {
                    ClassId = 4,
                    PupilId = 22
                },
                new ClassToPupil
                {
                    ClassId = 4,
                    PupilId = 23
                },
                new ClassToPupil
                {
                    ClassId = 4,
                    PupilId = 24
                },
                new ClassToPupil
                {
                    ClassId = 5,
                    PupilId = 32
                },
                new ClassToPupil
                {
                    ClassId = 5,
                    PupilId = 33
                },
                new ClassToPupil
                {
                    ClassId = 5,
                    PupilId = 34
                },
                new ClassToPupil
                {
                    ClassId = 5,
                    PupilId = 35
                },
                new ClassToPupil
                {
                    ClassId = 5,
                    PupilId = 36
                },
                new ClassToPupil
                {
                    ClassId = 5,
                    PupilId = 37
                },
                new ClassToPupil
                {
                    ClassId = 5,
                    PupilId = 38
                },
                new ClassToPupil
                {
                    ClassId = 5,
                    PupilId = 39
                },
                new ClassToPupil
                {
                    ClassId = 5,
                    PupilId = 40
                },
                new ClassToPupil
                {
                    ClassId = 5,
                    PupilId = 41
                });
        }
    }
}
