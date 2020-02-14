﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(e => e.Degree)
                .HasMaxLength(256);

            

            builder.HasMany(e => e.Classes)
                .WithOne(e => e.TeacherOf);

            builder.HasMany(e => e.Materials)
                .WithOne(e => e.Teacher);

            builder.HasOne(e => e.User)
                .WithOne(e => e.Teacher)
                .HasForeignKey<Teacher>(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.TeacherToDisciplines)
                .WithOne(e => e.Teacher);

            builder.HasMany(e => e.UpcomingEvents)
                .WithOne(e => e.Teacher);

            builder.HasData(
                new Teacher { Id = 1, UserId = 2, Degree = "Kindergarten teachers" },
                new Teacher { Id = 2, UserId = 1, Degree = "Kindergarten and elementary school teachers" },
                new Teacher { Id = 3, UserId = 3, Degree = "High school teachers" },
                new Teacher { Id = 4, UserId = 4, Degree = "Middle school teachers" },
                new Teacher { Id = 5, UserId = 25 }, //head-assistant
                new Teacher { Id = 6, UserId = 26 },
                new Teacher { Id = 7, UserId = 27 }, //master
                new Teacher { Id = 8, UserId = 28 },
                new Teacher { Id = 9, UserId = 29 }, //head-master
                new Teacher { Id = 10, UserId = 30 }
            );
        }
    }
}