using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(x => x.TeacherToDisciplines)
                .WithOne(x => x.Discipline);

            builder.HasMany(x => x.UpcomingTests)
                .WithOne(x => x.Discipline);

            builder.HasMany(e => e.Lessons)
                .WithOne(e => e.Discipline);

            builder.HasData(
                new Discipline { Id = 1, Name = "Ukrainian language" },
                new Discipline { Id = 2, Name = "Ukrainian literature" },
                new Discipline { Id = 3, Name = "English" },
                new Discipline { Id = 4, Name = "World Literature" },
                new Discipline { Id = 5, Name = "History of Ukraine" },
                new Discipline { Id = 6, Name = "World History" },
                new Discipline { Id = 7, Name = "Fundamentals of Law" },
                new Discipline { Id = 8, Name = "Art" },
                new Discipline { Id = 9, Name = "Algebra" },
                new Discipline { Id = 10, Name = "Geometry" },
                new Discipline { Id = 11, Name = "Biology" },
                new Discipline { Id = 12, Name = "Geography" },
                new Discipline { Id = 13, Name = "Physics" },
                new Discipline { Id = 14, Name = "Chemistry" },
                new Discipline { Id = 15, Name = "Work training" },
                new Discipline { Id = 16, Name = "Computer Science" },
                new Discipline { Id = 17, Name = "Основи здоров’я" },
                new Discipline { Id = 18, Name = "Physical Education" }
            );
        }
    }
}
