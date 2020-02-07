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
                //.HasColumnType("datetime")
                .IsRequired();

            builder.Property(e => e.Topic)
                .HasMaxLength(255);

            builder.Property(e => e.TestType)
                .HasMaxLength(255);

            builder.HasOne(e => e.Class)
                .WithMany(e => e.UpcomingTests)
                .HasForeignKey(e => e.ClassId); //Not in the context

            builder.HasOne(e => e.Discipline)
                .WithMany(e => e.UpcomingTests)
                .HasForeignKey(e => e.DisciplineId);
        }
    }
}
