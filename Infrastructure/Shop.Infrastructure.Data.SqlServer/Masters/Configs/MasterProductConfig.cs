using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Core.Domain.Masters.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructure.Data.SqlServer.Masters.Configs
{
    public class MasterProductConfig : IEntityTypeConfiguration<MasterProduct>
    {
        public void Configure(EntityTypeBuilder<MasterProduct> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Price).IsRequired();
            builder.Property(c => c.Discount).IsRequired();
            builder.Property(c => c.Description).IsRequired();
            builder.Property(c => c.ShortDescription).HasMaxLength(256).IsRequired();


        }
    }
}
