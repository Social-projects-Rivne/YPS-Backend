using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(256);
                

            builder.HasMany(e => e.Users)
                .WithOne(e => e.RoleOf);

            builder.HasData(new Role { Id = 1, Name = "pupil", Description = "Simple pupil" },
                new Role { Id = 2, Name = "teacher", Description = "Simple teacher which lead the lessons" },
                new Role { Id = 3, Name = "parent", Description = "Parent of the child pupil" },
                new Role { Id = 4, Name = "head-assistant", Description = "Head assistant of the school which create schedule"},
                new Role { Id = 5, Name = "master", Description = "Master of the system can create users"},
                new Role { Id = 6, Name = "head-master", Description = "Simple master but can create other users and masters"},
                new Role { Id = 7, Name = "admin", Description = "Main person of the system. Add new school"});
        }
    }
}
