using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class MarkConfiguration : IEntityTypeConfiguration<Mark>
    {
        public void Configure(EntityTypeBuilder<Mark> builder)
        {
            builder.Property(e => e.Value)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasOne(e => e.JournalColumn)
                .WithMany(e => e.Marks)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Pupil)
                .WithMany(e => e.Marks)
                .HasForeignKey(e => e.PupilId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.MarkType)
                .WithMany(e => e.Marks)
                .HasForeignKey(e => e.MarkTypeId);

            builder.HasOne(e => e.Homework)
                .WithMany(e => e.Marks);
        }
    }
}