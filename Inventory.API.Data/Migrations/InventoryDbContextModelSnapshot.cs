﻿// <auto-generated />
using Inventory.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inventory.API.Data.Migrations
{
    [DbContext(typeof(InventoryDbContext))]
    partial class InventoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("Inventory.API.Data.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("SupplierId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalStocks")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ItemCategoryId");

                    b.HasIndex("SupplierId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Monitor LED 20 Inch",
                            IsDeleted = false,
                            ItemCategoryId = 1,
                            ItemType = 2,
                            Name = "Monitor United-Star",
                            SupplierId = 1,
                            TotalStocks = 25,
                            WarehouseId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Laptop Work Station tipe W-540",
                            IsDeleted = false,
                            ItemCategoryId = 2,
                            ItemType = 2,
                            Name = "Laptop Thinkpad",
                            SupplierId = 1,
                            TotalStocks = 20,
                            WarehouseId = 1
                        });
                });

            modelBuilder.Entity("Inventory.API.Data.ItemCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ItemCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Ini adalah item yang memiliki Category Monitor",
                            IsDeleted = false,
                            Name = "Monitor"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Ini adalah item yang memiliki Category Laptop",
                            IsDeleted = false,
                            Name = "Laptop"
                        });
                });

            modelBuilder.Entity("Inventory.API.Data.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Danger Line 001",
                            Description = "Seed Data",
                            Email = "supplier01@gmail.com",
                            IsDeleted = false,
                            Name = "Supplier-01",
                            Telephone = "08981216969"
                        });
                });

            modelBuilder.Entity("Inventory.API.Data.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("TotalCapacity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsedCapacity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Warehouses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Danger Line 001",
                            IsDeleted = false,
                            Name = "Warehouse-01",
                            TotalCapacity = 5000,
                            UsedCapacity = 45
                        });
                });

            modelBuilder.Entity("Inventory.API.Data.Item", b =>
                {
                    b.HasOne("Inventory.API.Data.ItemCategory", "ItemCategory")
                        .WithMany("Items")
                        .HasForeignKey("ItemCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inventory.API.Data.Supplier", "Supplier")
                        .WithMany("Items")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inventory.API.Data.Warehouse", "Warehouse")
                        .WithMany("Items")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemCategory");

                    b.Navigation("Supplier");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("Inventory.API.Data.ItemCategory", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Inventory.API.Data.Supplier", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Inventory.API.Data.Warehouse", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
