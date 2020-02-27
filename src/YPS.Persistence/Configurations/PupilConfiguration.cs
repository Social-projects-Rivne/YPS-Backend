using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class PupilConfiguration : IEntityTypeConfiguration<Pupil>
    {
        public void Configure(EntityTypeBuilder<Pupil> builder)
        {


            builder.HasOne(e => e.ClassOf)
                .WithMany(e => e.Pupils)
                .HasForeignKey(e => e.ClassId);

            builder.HasOne(e => e.User)
                .WithOne(e => e.Pupil)
                .HasForeignKey<Pupil>(e => e.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Marks)
                .WithOne(e => e.Pupil);

            builder.HasMany(e => e.ParentToPupils)
                .WithOne(e => e.PupilOf);

            builder.HasData(
                new Pupil { Id = 15, ClassId = 1 },
                new Pupil { Id = 16, ClassId = 1 },
                new Pupil { Id = 17, ClassId = 1 },
                new Pupil { Id = 18, ClassId = 2 },
                new Pupil { Id = 19, ClassId = 2 },
                new Pupil { Id = 20, ClassId = 3 },
                new Pupil { Id = 21, ClassId = 3 },
                new Pupil { Id = 22, ClassId = 4 },
                new Pupil { Id = 23, ClassId = 4 },
                new Pupil { Id = 24, ClassId = 4 }
            );
        }
    }
}
