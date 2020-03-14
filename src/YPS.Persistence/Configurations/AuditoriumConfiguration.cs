using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class AuditoriumConfiguration : IEntityTypeConfiguration<Auditorium>
    {
        public void Configure(EntityTypeBuilder<Auditorium> builder)
        {
            builder .Property(e => e.Number)
                .HasMaxLength(5);

            builder .Property(e => e.Name)
                .HasMaxLength(50);

            builder.HasOne(e => e.School)
                .WithMany(e => e.Auditoriums)
                .HasForeignKey(e => e.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Lessons)
                .WithOne(e => e.Auditorium);
            
            builder.HasData(
                new Auditorium 
                {
                    Id = 1,
                    SchoolId = 2,
                    Number = 101,
                    Name = "Historical"
                },
                new Auditorium 
                {
                    Id = 2,
                    SchoolId = 2,
                    Number = 102,
                    Name = "Geographical"
                },
                new Auditorium
                {
                    Id = 3,
                    SchoolId = 2,
                    Number = 103,
                    Name = "Foreign"
                },
                new Auditorium
                {
                    Id = 4,
                    SchoolId = 2,
                    Number = 104,
                    Name = "Literary"
                },
                new Auditorium
                {
                    Id = 5,
                    SchoolId = 2,
                    Number = 323,
                    Name = "Astronomical"
                },
                new Auditorium
                {
                    Id = 6,
                    SchoolId = 2,
                    Number = 324,
                    Name = "Astronomical"
                }
            );
        }
    }
}
