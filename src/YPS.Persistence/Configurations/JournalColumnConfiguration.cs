using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class JournalColumnConfiguration : IEntityTypeConfiguration<JournalColumn>
    {
        public void Configure(EntityTypeBuilder<JournalColumn> builder)
        {
            builder.Property(e => e.Topic)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(e => e.Marks)
                .WithOne(e => e.JournalColumn)
                .HasForeignKey(e => e.JournalColumnId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Lesson)
                .WithOne(e => e.JournalColumn)
                .HasForeignKey<JournalColumn>(e => e.LessonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Homework)
                .WithOne(e => e.JournalColumn)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Journal)
                .WithMany(e => e.JournalColumns)
                .HasForeignKey(e => e.JournalId);

            builder.HasData(
                new JournalColumn
                {
                    Id = 1,
                    Topic = "Predicates",
                    LessonId = 109,
                    JournalId = 1
                },
                new JournalColumn
                {
                    Id = 2,
                    Topic = "Taras Bulba",
                    LessonId = 110,
                    JournalId = 1
                },
                new JournalColumn
                {
                    Id = 3,
                    Topic = "Phrasal words",
                    LessonId = 111,
                    JournalId = 1
                },
                new JournalColumn
                {
                    Id = 4,
                    Topic = "Chopin",
                    LessonId = 112,
                    JournalId = 1
                },
                new JournalColumn
                {
                    Id = 5,
                    Topic = "Yellow waters",
                    LessonId = 113,
                    JournalId = 1
                },
                new JournalColumn
                {
                    Id = 6,
                    Topic = "WW II",
                    LessonId = 114,
                    JournalId = 1
                },
                new JournalColumn
                {
                    Id = 7,
                    Topic = "Law&Order",
                    LessonId = 115,
                    JournalId = 1
                },
                new JournalColumn
                {
                    Id = 8,
                    Topic = "Flowers",
                    LessonId = 116,
                    JournalId = 1
                },
                new JournalColumn
                {
                    Id = 9,
                    Topic = "Tripple/Double",
                    LessonId = 117,
                    JournalId = 1
                },
                new JournalColumn
                {
                    Id = 10,
                    Topic = "S=2pr^2",
                    LessonId = 118,
                    JournalId = 1
                },
                new JournalColumn
                {
                    Id = 11,
                    Topic = "Fotosynthesys",
                    LessonId = 119,
                    JournalId = 1
                },
                new JournalColumn
                {
                    Id = 12,
                    Topic = "Where is Ukrain?",
                    LessonId = 120,
                    JournalId = 1
                },
                new JournalColumn
                {
                    Id = 13,
                    Topic = "Predicates",
                    LessonId = 139,
                    JournalId = 1
                },
                new JournalColumn
                {
                    Id = 14,
                    Topic = "Taras Bulba",
                    LessonId = 140,
                    JournalId = 1
                },
                new JournalColumn
                {
                    Id = 15,
                    Topic = "Phrasal words",
                    LessonId = 141,
                    JournalId = 1
                },
                new JournalColumn
                {
                    Id = 16,
                    Topic = "Chopin",
                    LessonId = 142,
                    JournalId = 1
                },
                new JournalColumn
                {
                    Id = 17,
                    Topic = "Yellow waters",
                    LessonId = 143,
                    JournalId = 1
                },
                new JournalColumn
                {
                    Id = 18,
                    Topic = "WW II",
                    LessonId = 144,
                    JournalId = 1
                },
                new JournalColumn
                {
                    Id = 19,
                    Topic = "Law&Order",
                    LessonId = 145,
                    JournalId = 1
                },
                new JournalColumn
                {
                    Id = 20,
                    Topic = "Flowers",
                    LessonId = 146,
                    JournalId = 1
                },
                new JournalColumn
                {
                    Id = 21,
                    Topic = "Tripple/Double",
                    LessonId = 147,
                    JournalId = 1
                },
                new JournalColumn
                {
                    Id = 22,
                    Topic = "S=2pr^2",
                    LessonId = 148,
                    JournalId = 1
                },
                new JournalColumn
                {
                    Id = 23,
                    Topic = "Fotosynthesys",
                    LessonId = 149,
                    JournalId = 1
                },
                new JournalColumn
                {
                    Id = 24,
                    Topic = "Where is Ukrain?",
                    LessonId = 150,
                    JournalId = 1
                }
            );
        }
    }
}
