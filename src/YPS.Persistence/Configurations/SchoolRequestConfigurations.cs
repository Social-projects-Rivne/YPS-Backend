using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class SchoolRequestConfigurations : IEntityTypeConfiguration<SchoolRequest>
    {
        public void Configure(EntityTypeBuilder<SchoolRequest> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.ShortName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Locality)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.PhoneNumb)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
