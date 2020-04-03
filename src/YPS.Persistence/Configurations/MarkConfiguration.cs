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

            builder.HasData(
                new Mark()
                {
                    Id = 1,
                    Value = "5",
                    JournalColumnId = 1,
                    MarkTypeId = 1,
                    PupilId = 32,
                    HomeworkId = null
                },
                new Mark()
                {
                    Id = 2,
                    Value = "5",
                    JournalColumnId = 1,
                    MarkTypeId = 2,
                    PupilId = 32,
                    HomeworkId = null
                },
                new Mark()
                {
                    Id = 3,
                    Value = "5",
                    JournalColumnId = 1,
                    MarkTypeId = 3,
                    PupilId = 32,
                    HomeworkId = null
                },
                new Mark()
                {
                    Id = 4,
                    Value = "2",
                    JournalColumnId = 2,
                    MarkTypeId = 1,
                    PupilId = 32,
                    HomeworkId = null
                }
            );
        }
    }
}