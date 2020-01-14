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
        public virtual DbSet<Class> Class { get; set; }
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UpcomingEvent>()
                .HasKey(c => new { c.ClassId, c.SchoolId});
            modelBuilder.Entity<ParentToPupil>()
                .HasKey(c => new {c.ParentId, c.PupilId});
            modelBuilder.Entity<Pupil>()
                .HasKey(c => new { c.ClassId, c.UserId});
            modelBuilder.Entity<Class>()
                .HasKey(c => new { c.Id});
            modelBuilder.Entity<Journal>()
                .HasKey(c => new { c.Id/*, c.ClassId */});
            modelBuilder.Entity<Teacher>()
                .HasKey(c => new { c.Id, c.SchoolId });
            //modelBuilder.Entity<ParentToPupil>()
            //    .HasKey(c => new { c.Id});
            modelBuilder.Entity<Pupil>()
                .HasMany(x => x.Marks)
                .WithOne(x => x.Pupil);
            modelBuilder.Entity<Mark>()
                .HasOne(x => x.Pupil)
                .WithMany(x => x.Marks);
            modelBuilder.Entity<Pupil>()
                .HasMany(x => x.ParentToPupils)
                .WithOne(x => x.PupilOf);
                
        }
    }

}