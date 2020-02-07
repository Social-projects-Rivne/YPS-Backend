using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class UpcomingEventConfigurations : IEntityTypeConfiguration<UpcomingEvent>
    {
        public void Configure(EntityTypeBuilder<UpcomingEvent> builder)
        {
            builder.Property(e => e.Title)
                .HasMaxLength(255);

            builder.Property(e => e.TimeOfCreation)
                //.HasColumnType("datetime")
                .IsRequired();

            builder.HasOne(e => e.School)
                .WithMany(e => e.UpcomingEvents)
                .HasForeignKey(e => e.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Teacher)
                .WithMany(e => e.UpcomingEvents)
                .HasForeignKey(e => e.TeacherId);

            builder.HasOne(e => e.Class)
                .WithMany(e => e.UpcomingEvents)
                .HasForeignKey(e => e.ClassId); //Not in the context
        }
    }
}
