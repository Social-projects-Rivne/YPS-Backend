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
            //builder.HasOne(e => e.ClassOf)
            //    .WithMany(e => e.Pupils)
            //    .HasForeignKey(e => e.ClassId);

            builder.HasOne(e => e.User)
                .WithOne(e => e.Pupil)
                .HasForeignKey<Pupil>(e => e.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Marks)
                .WithOne(e => e.Pupil);

            builder.HasMany(e => e.ParentToPupils)
                .WithOne(e => e.PupilOf);

            builder.HasMany(e => e.ClassToPupils)
                .WithOne(e => e.Pupil);
            builder.HasData(
                new Pupil { Id = 15 },
                new Pupil { Id = 16 },
                new Pupil { Id = 17 },
                new Pupil { Id = 18 },
                new Pupil { Id = 19 },
                new Pupil { Id = 20 },
                new Pupil { Id = 21 },
                new Pupil { Id = 22 },
                new Pupil { Id = 23 },
                new Pupil { Id = 24 }
            );
        }
    }
}
