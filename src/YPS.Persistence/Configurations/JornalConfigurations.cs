using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YPS.Domain.Entities;

namespace YPS.Persistence.Configurations
{
    class JornalConfigurations : IEntityTypeConfiguration<Journal>
    {
        public void Configure(EntityTypeBuilder<Journal> builder)
        {
            builder.HasMany(e => e.JournalColumns)
                .WithOne(e => e.Journal);

            builder.HasOne(e => e.Class)
                .WithMany(e => e.Journals)
                .HasForeignKey(e => e.ClassId); //Not in the DBContext
        }
    }
}
