using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class ParentToPupilConfiguration : IEntityTypeConfiguration<ParentToPupil>
    {
        public void Configure(EntityTypeBuilder<ParentToPupil> builder)
        {
            builder.HasKey(x => new { x.ParentId, x.PupilId });

            builder.HasOne(e => e.ParentOf)
                .WithMany(e => e.ParentToPupils)
                .HasForeignKey(e => e.ParentId)
                .IsRequired();

            builder.HasOne(e => e.PupilOf)
                .WithMany(e => e.ParentToPupils)
                .HasForeignKey(e => e.PupilId)
                .IsRequired();

            builder.HasData(
                new ParentToPupil { ParentId = 5, PupilId = 15 },
                new ParentToPupil { ParentId = 6, PupilId = 16 },
                new ParentToPupil { ParentId = 7, PupilId = 17 },
                new ParentToPupil { ParentId = 8, PupilId = 18 },
                new ParentToPupil { ParentId = 9, PupilId = 19 },
                new ParentToPupil { ParentId = 10, PupilId = 20 },
                new ParentToPupil { ParentId = 11, PupilId = 21 },
                new ParentToPupil { ParentId = 12, PupilId = 22 },
                new ParentToPupil { ParentId = 5, PupilId = 23 },
                new ParentToPupil { ParentId = 5, PupilId = 24 },
                new ParentToPupil { ParentId = 46, PupilId = 35 },
                new ParentToPupil { ParentId = 46, PupilId = 38 },
                new ParentToPupil { ParentId = 46, PupilId = 41 });
        }
    }
}
