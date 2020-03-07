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
        public DbSet<User> Users { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<JournalColumn> JournalColumns { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<MarkType> MarkTypes { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<ParentToPupil> ParentToPupils { get; set; }
        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherToDiscipline> TeacherToDisciplines { get; set; }
        public DbSet<UpcomingTest> UpcomingTests { get; set; }
        public DbSet<UpcomingEvent> UpcomingEvents { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SchoolRequest> SchoolRequests { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
        public DbSet<Auditorium> Auditoriums { get; set; }
        public DbSet<ClassToPupil> ClassesToPupils { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(YPSDbContext).Assembly);
        }
    }
}