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

            builder.HasData(new ParentToPupil { Id = 1, ParentId = 1, PupilId = 1 },
                new ParentToPupil { Id = 2, ParentId = 1, PupilId = 2 },
                new ParentToPupil { Id = 3, ParentId = 2, PupilId = 3 },
                new ParentToPupil { Id = 4, ParentId = 4, PupilId = 4 },
                new ParentToPupil { Id = 5, ParentId = 5, PupilId = 5 },
                new ParentToPupil { Id = 6, ParentId = 6, PupilId = 6 },
                new ParentToPupil { Id = 7, ParentId = 7, PupilId = 7 },
                new ParentToPupil { Id = 8, ParentId = 8, PupilId = 8 },
                new ParentToPupil { Id = 9, ParentId = 9, PupilId = 9 },
                new ParentToPupil { Id = 10, ParentId = 10, PupilId = 10 });
        }
    }
}
