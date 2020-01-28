using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using YPS.Application.Interfaces;
using YPS.Domain.Entities;


namespace YPS.Persistence
{
    public class YPSDbContext : DbContext, IYPSDbContext
    {
        public YPSDbContext(DbContextOptions<YPSDbContext> options) : base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<Discipline> Disciplines { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }
        public virtual DbSet<Journal> Journals { get; set; }
        public virtual DbSet<JournalColumn> JournalColumns { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<MarkType> MarkTypes { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<ParentToPupil> ParentToPupils { get; set; }
        public virtual DbSet<Pupil> Pupils { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TeacherToDiscipline> TeacherToDisciplines { get; set; }
        public virtual DbSet<UpcomingTest> UpcomingTests { get; set; }
        public virtual DbSet<UpcomingEvent> UpcomingEvents { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SchoolRequest> SchoolRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>()
                .HasOne(x => x.TeacherOf)
                .WithMany(x => x.Classes)
                .HasForeignKey(x => x.ClassTeacherId);
            modelBuilder.Entity<Teacher>()
                .HasMany(x => x.Classes)
                .WithOne(x => x.TeacherOf);

            modelBuilder.Entity<Day>()
                .HasMany(x => x.Schedules)
                .WithOne(x => x.Day)
                .HasForeignKey(x => x.DayId);
            modelBuilder.Entity<Schedule>()
                .HasOne(x => x.Day)
                .WithMany(x => x.Schedules);

            modelBuilder.Entity<Discipline>()
                .HasMany(x => x.TeacherToDisciplines)
                .WithOne(x => x.Discipline);
            modelBuilder.Entity<TeacherToDiscipline>()
                .HasOne(x => x.Discipline)
                .WithMany(x => x.TeacherToDisciplines)
                .HasForeignKey(x => x.DisciplineId);
            modelBuilder.Entity<Discipline>()
                .HasMany(x => x.UpcomingTests)
                .WithOne(x => x.Discipline);
            modelBuilder.Entity<UpcomingTest>()
                .HasOne(x => x.Discipline)
                .WithMany(x => x.UpcomingTests)
                .HasForeignKey(x => x.DisciplineId);

            modelBuilder.Entity<Homework>()
                .HasMany(x => x.JournalColumns)
                .WithOne(x => x.Homework);
            modelBuilder.Entity<JournalColumn>()
                .HasOne(x => x.Homework)
                .WithMany(x => x.JournalColumns)
                .HasForeignKey(x => x.HomeworkId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Journal>()
                .HasMany(x => x.JournalColumns)
                .WithOne(x => x.Journal);
            modelBuilder.Entity<JournalColumn>()
                .HasOne(x => x.Journal)
                .WithMany(x => x.JournalColumns)
                .HasForeignKey(x => x.JournalId);

            modelBuilder.Entity<JournalColumn>()
                .HasMany(x => x.Marks)
                .WithOne(x => x.JournalColumn);
            modelBuilder.Entity<Mark>()
                .HasOne(x => x.JournalColumn)
                .WithMany(x => x.Marks)
                .HasForeignKey(x => x.JournalColumnId);

            modelBuilder.Entity<Lesson>()
                .HasMany(x => x.JournalColumns)
                .WithOne(x => x.Lesson);
            modelBuilder.Entity<JournalColumn>()
                .HasOne(x => x.Lesson)
                .WithMany(x => x.JournalColumns)
                .HasForeignKey(x => x.LessonId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Lesson>()
                .HasMany(x => x.Schedules)
                .WithOne(x => x.Lesson);
            modelBuilder.Entity<Schedule>()
                .HasOne(x => x.Lesson)
                .WithMany(x => x.Schedules)
                .HasForeignKey(x => x.LessonId);

            modelBuilder.Entity<Mark>()
                .HasMany(x => x.Homeworks)
                .WithOne(x => x.Mark);
            modelBuilder.Entity<Homework>()
                .HasOne(x => x.Mark)
                .WithMany(x => x.Homeworks)
                .HasForeignKey(x => x.MarkId);

            modelBuilder.Entity<MarkType>()
                .HasMany(x => x.Marks)
                .WithOne(x => x.MarkType);
            modelBuilder.Entity<Mark>()
                .HasOne(x => x.MarkType)
                .WithMany(x => x.Marks)
                .HasForeignKey(x => x.MarkTypeId);

            modelBuilder.Entity<Material>()
                .HasOne(x => x.Teacher)
                .WithMany(x => x.Materials)
                .HasForeignKey(x => x.TeacherId);
            modelBuilder.Entity<Teacher>()
                .HasMany(x => x.Materials)
                .WithOne(x => x.Teacher);


            modelBuilder.Entity<Parent>()
                .HasMany(x => x.ParentToPupils)
                .WithOne(x => x.ParentOf);
            modelBuilder.Entity<ParentToPupil>()
                .HasOne(x => x.ParentOf)
                .WithMany(x => x.ParentToPupils)
                .HasForeignKey(x => x.ParentId);
            modelBuilder.Entity<Parent>()
                .HasOne(x => x.User)
                .WithOne(x => x.Parent)
                .HasForeignKey<Parent>(x => x.UserId);

            modelBuilder.Entity<ParentToPupil>()
                .HasOne(x => x.PupilOf)
                .WithMany(x => x.ParentToPupils)
                .HasForeignKey(x => x.PupilId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Pupil>()
                .HasMany(x => x.ParentToPupils)
                .WithOne(x => x.PupilOf);

            modelBuilder.Entity<Pupil>()
                .HasMany(x => x.Marks)
                .WithOne(x => x.Pupil);
            modelBuilder.Entity<Pupil>()
                .HasOne(x => x.User)
                .WithOne(x => x.Pupil)
                .HasForeignKey<Pupil>(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Mark>()
                .HasOne(x => x.Pupil)
                .WithMany(x => x.Marks)
                .HasForeignKey(x => x.PupilId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<School>()
                .HasMany(x => x.UpcomingEvents)
                .WithOne(x => x.School);
            modelBuilder.Entity<UpcomingEvent>()
                .HasOne(x => x.School)
                .WithMany(x => x.UpcomingEvents)
                .HasForeignKey(x => x.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Teacher>()
                .HasMany(x => x.Classes)
                .WithOne(x => x.TeacherOf);
            modelBuilder.Entity<Teacher>()
                .HasMany(x => x.TeacherToDisciplines)
                .WithOne(x => x.Teacher);
            modelBuilder.Entity<Teacher>()
                .HasOne(x => x.User)
                .WithOne(x => x.Teacher)
                .HasForeignKey<Teacher>(x => x.UserId);
            modelBuilder.Entity<TeacherToDiscipline>()
                .HasOne(x => x.Teacher)
                .WithMany(x => x.TeacherToDisciplines)
                .HasForeignKey(x => x.TeacherId);
            modelBuilder.Entity<TeacherToDiscipline>()
                .HasMany(x => x.Lessons)
                .WithOne(x => x.TeacherToDiscipline);
            modelBuilder.Entity<Lesson>()
                .HasOne(x => x.TeacherToDiscipline)
                .WithMany(x => x.Lessons)
                .HasForeignKey(x => x.TeacherToDisciplineId);

            modelBuilder.Entity<User>()
                .HasOne(x => x.Teacher)
                .WithOne(x => x.User);
            modelBuilder.Entity<User>()
                .HasOne(x => x.Parent)
                .WithOne(x => x.User);
            modelBuilder.Entity<User>()
                .HasOne(x => x.Pupil)
                .WithOne(x => x.User);

            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = "Headmaster", Description = "HeadMaster" });
        }
    }

}