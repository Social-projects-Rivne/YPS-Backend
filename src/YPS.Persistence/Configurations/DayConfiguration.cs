using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class DayConfiguration : IEntityTypeConfiguration<Day>
    {
        public void Configure(EntityTypeBuilder<Day> builder)
        {
            builder.Property(e => e.Name)
                .HasMaxLength(10)
                .IsRequired();

            builder.HasMany(x => x.Schedules)
                .WithOne(x => x.Day)
                .HasForeignKey(x => x.DayId);

            builder.HasData(new Day { Id = 1, Name = "Monday" }, new Day { Id = 2, Name = "Tuesday" },
                new Day { Id = 3, Name = "Wednesday" }, new Day { Id = 4, Name = "Thursday" },
                new Day { Id = 5, Name = "Friday" }, new Day { Id = 6, Name = "Saturday" }, new Day { Id = 7, Name = "Sunday" });
        }
    }
}
