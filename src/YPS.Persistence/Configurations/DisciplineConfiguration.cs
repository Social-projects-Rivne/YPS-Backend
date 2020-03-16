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

            builder.HasOne(e => e.School)
                .WithMany(e => e.Disciplines)
                .HasForeignKey(e => e.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Discipline { Id = 1, SchoolId = 1, Name = "Ukrainian" },
                new Discipline { Id = 2, SchoolId = 1, Name = "Ukrainian literature" },
                new Discipline { Id = 3, SchoolId = 1, Name = "English" },
                new Discipline { Id = 4, SchoolId = 1, Name = "Health Basics" },
                new Discipline { Id = 5, SchoolId = 1, Name = "History of Ukraine" },
                new Discipline { Id = 6, SchoolId = 1, Name = "World History" },
                new Discipline { Id = 7, SchoolId = 1, Name = "Work training" },
                new Discipline { Id = 8, SchoolId = 1, Name = "Art" },
                new Discipline { Id = 9, SchoolId = 1, Name = "Algebra" },
                new Discipline { Id = 10, SchoolId = 1, Name = "Geometry" },
                new Discipline { Id = 11, SchoolId = 2, Name = "Biology" },
                new Discipline { Id = 12, SchoolId = 2, Name = "Geography" },
                new Discipline { Id = 13, SchoolId = 2, Name = "Physics" },
                new Discipline { Id = 14, SchoolId = 2, Name = "Chemistry" },
                new Discipline { Id = 15, SchoolId = 2, Name = "Work training" },
                new Discipline { Id = 16, SchoolId = 2, Name = "Computer Science" },
                new Discipline { Id = 17, SchoolId = 2, Name = "Health Basics" },
                new Discipline { Id = 18, SchoolId = 2, Name = "Physical Education" }
            );
        }
    }
}
