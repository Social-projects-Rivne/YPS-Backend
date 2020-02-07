using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class ParentToPupilConfigurations : IEntityTypeConfiguration<ParentToPupil>
    {
        public void Configure(EntityTypeBuilder<ParentToPupil> builder)
        {
            builder.HasOne(e => e.ParentOf)
                .WithMany(e => e.ParentToPupils)
                .HasForeignKey(e => e.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.PupilOf)
                .WithMany(e => e.ParentToPupils)
                .HasForeignKey(e => e.PupilId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
