using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.Property(e => e.LessonDate)
               .IsRequired();

            builder.Property(e => e.LessonNumber)
               .IsRequired();

            builder.Property(e => e.LessonTimeGap)
               .IsRequired();

            builder.HasOne(e => e.Teacher)
                .WithMany(e => e.Lessons)
                .HasForeignKey(e => e.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Class)
                .WithMany(e => e.Lessons)
                .HasForeignKey(e => e.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Discipline)
                .WithMany(e => e.Lessons)
                .HasForeignKey(e => e.DisciplineId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.JournalColumn)
                .WithOne(e => e.Lesson);

            builder.HasOne(e => e.Auditorium)
                .WithMany(e => e.Lessons)
                .HasForeignKey(e => e.AuditoriumId);

            builder.HasData(
                //Monday                
                new Lesson() 
                { 
                    Id = 1,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 3, 9),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 1,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 2,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 3, 9),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 2,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 3,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 3, 9),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 3,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 4,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 3, 9),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 4,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 5,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 3, 9),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 5,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 6,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 3, 9),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 6,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Tuesday
                new Lesson()
                {
                    Id = 7,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 3, 10),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 7,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 8,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 3, 10),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 8,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 9,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 3, 10),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 9,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 10,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 3, 10),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 10,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 11,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 3, 10),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 11,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 12,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 3, 10),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 12,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Wednesday
                new Lesson()
                {
                    Id = 13,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 3, 11),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 13,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 14,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 3, 11),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 14,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 15,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 3, 11),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 15,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 16,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 3, 11),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 16,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 17,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 3, 11),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 17,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 18,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 3, 11),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 18,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Thursday
                new Lesson()
                {
                    Id = 19,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 3, 12),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 1,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 20,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 3, 12),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 2,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 21,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 3, 12),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 3,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 22,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 3, 12),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 4,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 23,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 3, 12),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 5,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 24,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 3, 12),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 6,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Friday
                new Lesson()
                {
                    Id = 25,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 3, 13),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 7,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 26,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 3, 13),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 8,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 27,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 3, 13),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 9,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 28,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 3, 13),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 10,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 29,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 3, 13),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 11,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 30,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 3, 13),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 12,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Monday                
                new Lesson()
                {
                    Id = 31,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 3, 16),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 1,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 32,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 3, 16),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 2,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 33,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 3, 16),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 3,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 34,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 3, 16),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 4,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 35,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 3, 16),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 5,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 36,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 3, 16),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 6,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Tuesday
                new Lesson()
                {
                    Id = 37,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 3, 17),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 7,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 38,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 3, 17),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 8,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 39,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 3, 17),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 9,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 40,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 3, 17),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 10,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 41,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 3, 17),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 11,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 42,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 3, 17),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 12,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Wednesday
                new Lesson()
                {
                    Id = 43,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 3, 18),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 13,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 44,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 3, 18),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 14,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 45,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 3, 18),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 15,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 46,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 3, 18),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 16,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 47,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 3, 18),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 17,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 48,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 3, 18),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 18,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Thursday
                new Lesson()
                {
                    Id = 49,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 3, 19),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 1,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 50,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 3, 19),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 2,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 51,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 3, 19),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 3,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 52,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 3, 19),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 4,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 53,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 3, 19),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 5,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 54,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 3, 19),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 6,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Friday
                new Lesson()
                {
                    Id = 55,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 3, 20),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 7,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 56,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 3, 20),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 8,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 57,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 3, 20),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 9,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 58,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 3, 20),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 10,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 59,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 3, 20),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 11,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 60,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 3, 20),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 12,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Monday                
                new Lesson()
                {
                    Id = 61,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 3, 23),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 1,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 62,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 3, 23),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 2,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 63,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 3, 23),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 3,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 64,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 3, 23),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 4,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 65,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 3, 23),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 5,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 66,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 3, 23),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 6,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Tuesday
                new Lesson()
                {
                    Id = 67,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 3, 24),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 7,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 68,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 3, 24),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 8,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 69,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 3, 24),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 9,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 70,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 3, 24),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 10,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 71,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 3, 24),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 11,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 72,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 3, 24),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 12,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Wednesday
                new Lesson()
                {
                    Id = 73,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 3, 25),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 13,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 74,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 3, 25),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 14,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 75,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 3, 25),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 15,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 76,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 3, 25),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 16,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 77,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 3, 25),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 17,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 78,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 3, 25),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 18,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Thursday
                new Lesson()
                {
                    Id = 79,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 3, 26),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 1,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 80,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 3, 26),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 2,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 81,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 3, 26),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 3,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 82,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 3, 26),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 4,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 83,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 3, 26),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 5,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 84,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 3, 26),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 6,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Friday
                new Lesson()
                {
                    Id = 85,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 3, 27),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 7,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 86,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 3, 27),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 8,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 87,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 3, 27),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 9,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 88,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 3, 27),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 10,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 89,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 3, 27),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 11,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 90,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 3, 27),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 12,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Monday                
                new Lesson()
                {
                    Id = 91,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 3, 30),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 1,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 92,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 3, 30),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 2,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 93,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 3, 30),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 3,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 94,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 3, 30),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 4,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 95,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 3, 30),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 5,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 96,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 3, 30),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 6,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Tuesday
                new Lesson()
                {
                    Id = 97,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 3, 31),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 7,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 98,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 3, 31),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 8,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 99,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 3, 31),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 9,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 100,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 3, 31),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 10,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 101,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 3, 31),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 11,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 102,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 3, 31),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 12,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Wednesday
                new Lesson()
                {
                    Id = 103,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 3, 1),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 13,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 104,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 3, 1),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 14,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 105,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 4, 1),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 15,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 106,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 4, 1),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 16,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 107,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 4, 1),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 17,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 108,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 4, 1),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 18,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Thursday
                new Lesson()
                {
                    Id = 109,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 4, 2),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 1,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 110,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 4, 2),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 2,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 111,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 4, 2),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 3,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 112,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 4, 2),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 4,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 113,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 4, 2),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 5,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 114,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 4, 2),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 6,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Friday
                new Lesson()
                {
                    Id = 115,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 4, 3),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 7,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 116,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 4, 3),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 8,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 117,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 4, 3),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 9,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 118,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 4, 3),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 10,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 119,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 4, 3),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 11,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 120,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 4, 3),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 12,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Monday                
                new Lesson()
                {
                    Id = 121,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 4, 6),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 1,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 122,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 4, 6),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 2,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 123,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 4, 6),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 3,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 124,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 4, 6),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 4,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 125,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 4, 6),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 5,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 126,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 4, 6),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 6,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Tuesday
                new Lesson()
                {
                    Id = 127,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 4, 7),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 7,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 128,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 4, 7),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 8,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 129,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 4, 7),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 9,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 130,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 4, 7),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 10,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 131,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 4, 7),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 11,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 132,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 4, 7),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 12,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Wednesday
                new Lesson()
                {
                    Id = 133,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 4, 8),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 13,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 134,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 4, 8),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 14,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 135,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 4, 8),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 15,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 136,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 4, 8),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 16,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 137,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 4, 8),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 17,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 138,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 4, 8),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 18,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Thursday
                new Lesson()
                {
                    Id = 139,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 4, 9),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 1,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 140,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 4, 9),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 2,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 141,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 4, 9),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 3,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 142,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 4, 9),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 4,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 143,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 4, 9),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 5,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 144,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 4, 9),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 6,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Friday
                new Lesson()
                {
                    Id = 145,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 4, 10),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 7,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 146,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 4, 10),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 8,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 147,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 4, 10),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 9,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 148,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 4, 10),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 10,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 149,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 4, 10),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 11,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 150,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 4, 10),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 12,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Monday                
                new Lesson()
                {
                    Id = 151,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 4, 13),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 1,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 152,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 4, 13),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 2,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 153,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 4, 13),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 3,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 154,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 4, 13),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 4,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 155,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 4, 13),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 5,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 156,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 4, 13),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 6,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Tuesday
                new Lesson()
                {
                    Id = 157,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 4, 14),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 7,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 158,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 4, 14),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 8,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 159,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 4, 14),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 9,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 160,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 4, 14),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 10,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 161,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 4, 14),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 11,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 162,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 4, 14),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 12,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Wednesday
                new Lesson()
                {
                    Id = 163,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 4, 15),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 13,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 164,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 4, 15),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 14,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 165,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 4, 15),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 15,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 166,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 4, 15),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 16,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 167,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 4, 15),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 17,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 168,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 4, 15),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 18,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Thursday
                new Lesson()
                {
                    Id = 169,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 4, 16),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 1,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 170,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 4, 16),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 2,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 171,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 4, 16),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 3,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 172,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 4, 16),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 4,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 173,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 4, 16),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 5,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 174,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 4, 16),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 6,
                    TeacherId = 43,
                    ClassId = 5
                },

                //Friday
                new Lesson()
                {
                    Id = 175,
                    LessonNumber = 1,
                    LessonDate = new DateTime(2020, 4, 17),
                    LessonTimeGap = "8:00-8:45",
                    AuditoriumId = 1,
                    DisciplineId = 7,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 176,
                    LessonNumber = 2,
                    LessonDate = new DateTime(2020, 4, 17),
                    LessonTimeGap = "8:50-9:35",
                    AuditoriumId = 2,
                    DisciplineId = 8,
                    TeacherId = 43,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 177,
                    LessonNumber = 3,
                    LessonDate = new DateTime(2020, 4, 17),
                    LessonTimeGap = "9:45-10:30",
                    AuditoriumId = 3,
                    DisciplineId = 9,
                    TeacherId = 44,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 178,
                    LessonNumber = 4,
                    LessonDate = new DateTime(2020, 4, 17),
                    LessonTimeGap = "10:45-11:30",
                    AuditoriumId = 4,
                    DisciplineId = 10,
                    TeacherId = 45,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 179,
                    LessonNumber = 5,
                    LessonDate = new DateTime(2020, 4, 17),
                    LessonTimeGap = "11:40-12:25",
                    AuditoriumId = 5,
                    DisciplineId = 11,
                    TeacherId = 42,
                    ClassId = 5
                },
                new Lesson()
                {
                    Id = 180,
                    LessonNumber = 6,
                    LessonDate = new DateTime(2020, 4, 17),
                    LessonTimeGap = "12:35-13:20",
                    AuditoriumId = 6,
                    DisciplineId = 12,
                    TeacherId = 43,
                    ClassId = 5
                }
            );
        }
    }
}
