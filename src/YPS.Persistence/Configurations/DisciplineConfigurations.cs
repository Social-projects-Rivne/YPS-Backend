using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class DisciplineConfigurations : IEntityTypeConfiguration<Discipline>
    {
        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.Property(e => e.Name)
                .HasMaxLength(100);

            builder.HasMany(x => x.TeacherToDisciplines)
                .WithOne(x => x.Discipline);

            builder.HasMany(x => x.UpcomingTests)
                .WithOne(x => x.Discipline);

            builder.HasData(new Discipline { Id = 1, Name = "Math" },
                new Discipline { Id = 2, Name = "English" },
                new Discipline { Id = 3, Name = "Germany" });
        }
    }
}
