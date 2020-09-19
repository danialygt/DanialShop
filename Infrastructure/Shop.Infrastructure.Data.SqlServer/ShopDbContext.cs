using Microsoft.EntityFrameworkCore;
using Shop.Core.Domain.Categories.Entities;
using Shop.Core.Domain.Customers.Entities;
using Shop.Core.Domain.Masters.Entities;
using Shop.Core.Domain.Orders.Entities;
using Shop.Core.Domain.Photos.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructure.Data.SqlServer
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerContact> CustomerContacts { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<MasterProduct> MasterProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Photo> Photos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }



    }
}
