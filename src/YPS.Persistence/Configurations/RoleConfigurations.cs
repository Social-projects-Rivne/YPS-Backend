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

            builder.HasData(new Role { Id = 1, Name = "Pupil", Description = "Simple pupil"},
                new Role { Id = 2, Name = "Teacher", Description = "Simple teacher which lead the lessons"},
                new Role { Id = 3, Name = "Parent", Description = "Parent of the child pupil"},
                new Role {Id = 4, Name = "Head master", Description = "Head master of the school which create schedule"});
        }
    }
}
