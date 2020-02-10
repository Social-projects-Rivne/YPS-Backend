using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class UpcomingTestConfigurations : IEntityTypeConfiguration<UpcomingTest>
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
        }
    }
}
