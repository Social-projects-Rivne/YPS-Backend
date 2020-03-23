using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.ShortName)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(e => e.UpcomingEvents)
                .WithOne(e => e.School);

            builder.HasMany(e => e.Auditoriums)
                .WithOne(e => e.School);

            builder.HasMany(e => e.Disciplines)
                .WithOne(e => e.School);

            builder.HasData(
                new School
                {
                    Id = 1,
                    Name = "Kindergarten and elementary school №1",
                    ShortName = "Kind&E №1",
                    Address = "Litovska 1",
                    Locality = "Rivne",
                    Email = "schoonnumber1@gmail.com"
                },
                new School
                {
                    Id = 2,
                    Name = "High school 'Smile' of New-York",
                    ShortName = "HS 'Smile'",
                    Address = "Rockaway Boulevard",
                    Locality = "New yourk",
                    Email = "smileschool@gmail.com"
                }
            );
        }
    }
}
