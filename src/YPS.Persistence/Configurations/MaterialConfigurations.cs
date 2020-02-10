using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class MaterialConfigurations : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.Property(e => e.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(e => e.FileUrl)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(e => e.Teacher)
                .WithMany(e => e.Materials)
                .HasForeignKey(e => e.TeacherId);
        }
    }
}
