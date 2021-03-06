﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class UpcomingEventConfiguration : IEntityTypeConfiguration<UpcomingEvent>
    {
        public void Configure(EntityTypeBuilder<UpcomingEvent> builder)
        {
            builder.Property(e => e.Title)
                .HasMaxLength(255);

            builder.Property(e => e.Content)
                .HasMaxLength(5000);

            builder.Property(e => e.TimeOfCreation)
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

            builder.HasData(
                new UpcomingEvent
                {
                    Id = 1,
                    ClassId = 1,
                    SchoolId = 1,
                    Title = "Big event for a 1-A",
                    Content = "First lesson of a mathematics. Come with parent and friends.",
                    TeacherId = 1,
                    TimeOfCreation = DateTime.Now,
                    ScheduledDate = DateTime.Now.AddDays(3)
                },
                new UpcomingEvent
                {
                    Id = 6,
                    ClassId = 1,
                    SchoolId = 1,
                    Title = "Visit to cinema 1-A",
                    Content = "Our class is going to visit our city's cinema for watching historical film.",
                    TeacherId = 1,
                    TimeOfCreation = DateTime.Now,
                    ScheduledDate = DateTime.Now.AddDays(3)
                },
                new UpcomingEvent
                {
                    Id = 5,
                    ClassId = 1,
                    SchoolId = 1,
                    Title = "Collecting money on new tv for a 1-A",
                    Content = "We will buy a new TV.",
                    TeacherId = 1,
                    TimeOfCreation = DateTime.Now,
                    ScheduledDate = DateTime.Now.AddDays(3)
                },
                new UpcomingEvent
                {
                    Id = 2,
                    ClassId = null,
                    SchoolId = 1,
                    Title = "Happy birthday of our school",
                    Content = "Happy birthday of our school 'Kindergarten and elementary school №1' A lot of fun and chill come with parents and friends.",
                    TimeOfCreation = DateTime.Now,
                    ScheduledDate = DateTime.Now.AddDays(3),
                    TeacherId = 25 //We can add event by teacher for another school. BUG! For example try 6 it's a head-master of 2 school
                },
                new UpcomingEvent
                {
                    Id = 3,
                    ClassId = 3,
                    SchoolId = 2,
                    Title = "Meeting for a 11-B before ZNO",
                    Content = "Come to the cab.143 to head important information about your future tests.",
                    TeacherId = 3,
                    TimeOfCreation = DateTime.Now,
                    ScheduledDate = DateTime.Now.AddDays(3)
                },
                new UpcomingEvent
                {
                    Id = 4,
                    ClassId = null,
                    SchoolId = 1,
                    Title = "We are going to forest",
                    Content = "Our school is going to excursion in forest.",
                    TimeOfCreation = DateTime.Now,
                    ScheduledDate = DateTime.Now.AddDays(3),
                    TeacherId = 25
                });
        }
    }
}
