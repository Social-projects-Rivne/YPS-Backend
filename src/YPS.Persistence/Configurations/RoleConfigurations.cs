using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class RoleConfigurations : IEntityTypeConfiguration<Role>
    {
        /// <summary>
        /// Не чіпать
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasMany(e => e.Users)
                .WithOne(e => e.RoleOf); //Not in the context

            builder.HasData(new Role { Id = 1, Name = "Pupil", Description = "Simple pupil" },
                new Role { Id = 2, Name = "Teacher", Description = "Simple teacher which lead the lessons" },
                new Role { Id = 3, Name = "Parent", Description = "Parent of the child pupil" },
                new Role { Id = 4, Name = "Head assistant", Description = "Head assistant of the school which create schedule"},
                new Role { Id = 5, Name = "Master", Description = "Master of the system can create users"},
                new Role { Id = 6, Name = "Head master", Description = "Simple master but can create other users and masters"},
                new Role { Id = 7, Name = "Admin", Description = "Main person of the system. Add new school"});
        }
    }
}
