﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YPS.Domain.Entities;

namespace YPS.Application.Interfaces
{
    public interface IYPSDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Class> Classes { get; set; }
        DbSet<Discipline> Disciplines { get; set; }
        DbSet<Homework> Homeworks { get; set; }
        DbSet<Journal> Journals { get; set; }
        DbSet<JournalColumn> JournalColumns { get; set; }
        DbSet<Lesson> Lessons { get; set; }
        DbSet<Mark> Marks { get; set; }
        DbSet<MarkType> MarkTypes { get; set; }
        DbSet<Material> Materials { get; set; }
        DbSet<Parent> Parents { get; set; }
        DbSet<ParentToPupil> ParentToPupils { get; set; }
        DbSet<Pupil> Pupils { get; set; }
        DbSet<School> Schools { get; set; }
        DbSet<Teacher> Teachers { get; set; }
        DbSet<TeacherToDiscipline> TeacherToDisciplines { get; set; }
        DbSet<UpcomingTest> UpcomingTests { get; set; }
        DbSet<UpcomingEvent> UpcomingEvents { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<SchoolRequest> SchoolRequests { get; set; }
        DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
        DbSet<Auditorium> Auditoriums { get; set; }
        DbSet<ClassToPupil> ClassesToPupils { get; set; }
        DbSet<ClassToDiscipline> ClassesToDisciplines { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
