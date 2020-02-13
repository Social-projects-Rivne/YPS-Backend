using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(YPSDbContext).Assembly);
        }
    }
}