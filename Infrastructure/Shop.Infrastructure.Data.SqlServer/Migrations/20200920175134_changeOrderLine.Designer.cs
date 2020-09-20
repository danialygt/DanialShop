﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.Infrastructure.Data.SqlServer;

namespace Shop.Infrastructure.Data.SqlServer.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    [Migration("20200920175134_changeOrderLine")]
    partial class changeOrderLine
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Shop.Core.Domain.Categories.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<long>("PhotoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("PhotoId")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Shop.Core.Domain.Customers.Entities.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Provience")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Shop.Core.Domain.Masters.Entities.Master", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("MembershipDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("PhotoId")
                        .HasColumnType("bigint");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Masters");
                });

            modelBuilder.Entity("Shop.Core.Domain.Masters.Entities.MasterProduct", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Discount")
                        .HasColumnType("bigint");

                    b.Property<long>("MasterId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MasterId");

                    b.ToTable("MasterProducts");
                });

            modelBuilder.Entity("Shop.Core.Domain.Orders.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentId")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Shop.Core.Domain.Orders.Entities.OrderLine", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<long>("Discount")
                        .HasColumnType("bigint");

                    b.Property<long>("MasterProductId")
                        .HasColumnType("bigint");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MasterProductId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("Shop.Core.Domain.Payments.Entities.Payment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("PaymentValue")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Shop.Core.Domain.Photos.Entities.Photo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("MasterId")
                        .HasColumnType("bigint");

                    b.Property<long?>("MasterProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000)
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.HasIndex("MasterId")
                        .IsUnique()
                        .HasFilter("[MasterId] IS NOT NULL");

                    b.HasIndex("MasterProductId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Shop.Core.Domain.Categories.Entities.Category", b =>
                {
                    b.HasOne("Shop.Core.Domain.Categories.Entities.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Shop.Core.Domain.Photos.Entities.Photo", "Photo")
                        .WithOne()
                        .HasForeignKey("Shop.Core.Domain.Categories.Entities.Category", "PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Shop.Core.Domain.Masters.Entities.MasterProduct", b =>
                {
                    b.HasOne("Shop.Core.Domain.Categories.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Core.Domain.Masters.Entities.Master", "Master")
                        .WithMany("MasterProducts")
                        .HasForeignKey("MasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Shop.Core.Domain.Orders.Entities.Order", b =>
                {
                    b.HasOne("Shop.Core.Domain.Customers.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Shop.Core.Domain.Orders.Entities.OrderLine", b =>
                {
                    b.HasOne("Shop.Core.Domain.Masters.Entities.MasterProduct", "MasterProduct")
                        .WithMany()
                        .HasForeignKey("MasterProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Core.Domain.Orders.Entities.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Shop.Core.Domain.Payments.Entities.Payment", b =>
                {
                    b.HasOne("Shop.Core.Domain.Customers.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Shop.Core.Domain.Photos.Entities.Photo", b =>
                {
                    b.HasOne("Shop.Core.Domain.Masters.Entities.Master", null)
                        .WithOne("Photo")
                        .HasForeignKey("Shop.Core.Domain.Photos.Entities.Photo", "MasterId");

                    b.HasOne("Shop.Core.Domain.Masters.Entities.MasterProduct", null)
                        .WithMany("Photos")
                        .HasForeignKey("MasterProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
