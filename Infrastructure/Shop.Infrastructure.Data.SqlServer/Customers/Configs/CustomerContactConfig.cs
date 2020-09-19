using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Core.Domain.Customers.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructure.Data.SqlServer.Customers.Configs
{
    public class CustomerContactConfig : IEntityTypeConfiguration<CustomerContact>
    {
        public void Configure(EntityTypeBuilder<CustomerContact> builder)
        {
            builder.Property(c => c.Provience).HasMaxLength(50);
            builder.Property(c => c.City).HasMaxLength(50);
            builder.Property(c => c.Phone).HasMaxLength(20);
            builder.Property(c => c.Address).HasMaxLength(256);

        }
    }
}
