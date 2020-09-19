using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Core.Domain.Masters.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructure.Data.SqlServer.Masters.Configs
{
    public class MasterConfig : IEntityTypeConfiguration<Master>
    {
        public void Configure(EntityTypeBuilder<Master> builder)
        {
            builder.Property(c => c.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.LastName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Description).IsRequired();
            builder.Property(c => c.ShortDescription).HasMaxLength(256).IsRequired();
            


            builder.HasOne(c => c.Photo).WithOne().HasForeignKey("Photo","MasterId");
        }
    }
}
