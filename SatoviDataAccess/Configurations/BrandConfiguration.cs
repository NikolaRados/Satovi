using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SatoviDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SatoviDataAccess.Configurations
{
    class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {

            builder.Property(b => b.BrandName).IsRequired();

            builder.HasIndex(b => b.BrandName).IsUnique();

            builder.Property(b => b.CreatedAt).HasDefaultValueSql("GETDATE()");

        }
    }
}
