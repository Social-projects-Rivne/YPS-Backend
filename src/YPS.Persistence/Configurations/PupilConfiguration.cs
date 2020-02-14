﻿using System;
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
                .HasForeignKey<Pupil>(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Marks)
                .WithOne(e => e.Pupil);

            builder.HasMany(e => e.ParentToPupils)
                .WithOne(e => e.PupilOf);

            builder.HasData(
                new Pupil { Id = 1, UserId = 15, ClassId = 1 },
                new Pupil { Id = 2, UserId = 16, ClassId = 1 },
                new Pupil { Id = 3, UserId = 17, ClassId = 1 },
                new Pupil { Id = 4, UserId = 18, ClassId = 2 },
                new Pupil { Id = 5, UserId = 19, ClassId = 2 },
                new Pupil { Id = 6, UserId = 20, ClassId = 3 },
                new Pupil { Id = 7, UserId = 21, ClassId = 3 },
                new Pupil { Id = 8, UserId = 22, ClassId = 4 },
                new Pupil { Id = 9, UserId = 23, ClassId = 4 },
                new Pupil { Id = 10, UserId = 24, ClassId = 4 }
            );
        }
    }
}