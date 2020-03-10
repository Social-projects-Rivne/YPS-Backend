using System;
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

            builder.HasOne(e => e.User)
                .WithOne(e => e.Teacher)
                .HasForeignKey<Teacher>(e => e.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Classes)
                .WithOne(e => e.TeacherOf);

            builder.HasMany(e => e.Materials)
                .WithOne(e => e.Teacher);

            builder.HasMany(e => e.Lessons)
                .WithOne(e => e.Teacher);

            builder.HasMany(e => e.TeacherToDisciplines)
                .WithOne(e => e.Teacher);

            builder.HasMany(e => e.UpcomingEvents)
                .WithOne(e => e.Teacher);

            builder.HasMany(e => e.UpcomingTests)
                .WithOne(e => e.Teacher);

            builder.HasData(
                new Teacher { 
                    Id = 2, 
                    Degree = "Kindergarten teachers" 
                },
                new Teacher { 
                    Id = 1, 
                    Degree = "Kindergarten and elementary school teachers" 
                },
                new Teacher { 
                    Id = 3, 
                    Degree = "High school teachers" 
                },
                new Teacher { 
                    Id = 4, 
                    Degree = "Middle school teachers" 
                },
                new Teacher { Id = 25 }, //head-assistant
                new Teacher { Id = 26 },
                new Teacher { Id = 27 }, //master
                new Teacher { Id = 28 },
                new Teacher { Id = 29 }, //head-master
                new Teacher { Id = 30 },
                new Teacher
                {
                    Id = 42,
                    Degree = "Best teacher of the Year"
                },
                new Teacher
                {
                    Id = 43,
                    Degree = "Teacher of Physics"
                },
                new Teacher
                {
                    Id = 44,
                    Degree = "Teacher of Humanities"
                },
                new Teacher
                {
                    Id = 45,
                    Degree = "Teacher of Math Sciences"
                }
            );
        }
    }
}
