using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Core.Domain.Customers.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructure.Data.SqlServer.Customers.Configs
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.LastName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.NationalCode).HasMaxLength(10).IsRequired();

        }
    }
}


