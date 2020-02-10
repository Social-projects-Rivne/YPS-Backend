using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class UpcomingTestConfiguration : IEntityTypeConfiguration<UpcomingTest>
    {
        public void Configure(EntityTypeBuilder<UpcomingTest> builder)
        {
            builder.Property(e => e.Date)
                .IsRequired();

            builder.Property(e => e.Topic)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.TestType)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(e => e.Class)
                .WithMany(e => e.UpcomingTests)
                .HasForeignKey(e => e.ClassId);

            builder.HasOne(e => e.Discipline)
                .WithMany(e => e.UpcomingTests)
                .HasForeignKey(e => e.DisciplineId);

            builder.HasData(new UpcomingTest
            {
                Id = 1,
                TestType = "Test", Topic = "Adding and subtracting numbers",
                ClassId = 1, DisciplineId = 1,
                Date = DateTime.MaxValue
            }, 
            new UpcomingTest
            {
                Id = 2,
                TestType = "Test", Topic = "Using complex object in English dialogs",
                ClassId = 4, DisciplineId = 2,
                Date = DateTime.MaxValue
            });
        }
    }
}
