using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SatoviDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SatoviDataAccess.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.Property(i => i.Src).IsRequired();
            builder.Property(i => i.Alt).HasMaxLength(20);

            builder.HasIndex(i => i.Src).IsUnique();

            builder.Property(i => i.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
