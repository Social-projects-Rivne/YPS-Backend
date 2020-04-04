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

            builder.HasOne(e => e.Teacher)
                .WithMany(e => e.UpcomingTests)
                .HasForeignKey(e => e.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new UpcomingTest
                {
                    Id = 1,
                    TestType = "Test",
                    Topic = "Adding and subtracting numbers",
                    ClassId = 1,
                    DisciplineId = 20,
                    Date = DateTime.Now,
                    ScheduledDate = DateTime.Now.AddDays(3),
                    TeacherId = 1
                },
                new UpcomingTest
                {
                    Id = 2,
                    TestType = "Test",
                    Topic = "Calculating Power of TurboPapichPortal2",
                    ClassId = 4,
                    DisciplineId = 7,
                    Date = DateTime.MaxValue,
                    ScheduledDate = DateTime.Now.AddDays(3),
                    TeacherId = 4
                },
                new UpcomingTest
                {
                    Id = 3,
                    TestType = "Test",
                    Topic = "Course work",
                    ClassId = 5,
                    DisciplineId = 18,
                    Date = DateTime.MaxValue,
                    ScheduledDate = DateTime.Now.AddDays(3),
                    TeacherId = 43
                },
                new UpcomingTest
                {
                    Id = 4,
                    TestType = "Test",
                    Topic = "Calculating Power of TurboPapichPortal2",
                    ClassId = 5,
                    DisciplineId = 3,
                    Date = DateTime.Now,
                    ScheduledDate = DateTime.Now.AddDays(3),
                    TeacherId = 42
                },
                new UpcomingTest
                {
                    Id = 5,
                    TestType = "General test",
                    Topic = "Course work",
                    ClassId = 5,
                    DisciplineId = 13,
                    Date = DateTime.Now,
                    ScheduledDate = DateTime.Now.AddDays(3),
                    TeacherId = 42
                });
        }
    }
}
