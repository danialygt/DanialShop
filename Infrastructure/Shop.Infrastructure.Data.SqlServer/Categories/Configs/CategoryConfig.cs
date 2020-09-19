using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Core.Domain.Categories.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructure.Data.SqlServer.Categories.Configs
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            
            
            builder.HasMany(c => c.Children).WithOne(c => c.Parent)
                .HasForeignKey(c => c.ParentId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Photo).WithOne();
        }
    }
}
