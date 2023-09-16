using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Data
{
    public class InventoryDbContext : IdentityDbContext<ApiUser>
    {
        public InventoryDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ItemCategory>().HasData(
                new ItemCategory
                {
                    Id = 1,
                    Name = "Monitor",
                    Description = "Ini adalah item yang memiliki Category Monitor"
                },
                new ItemCategory
                {
                    Id = 2,
                    Name = "Laptop",
                    Description = "Ini adalah item yang memiliki Category Laptop"
                }
            );
            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    Name = "Monitor United-Star",
                    Description = "Monitor LED 20 Inch",
                    TotalStocks = 25,
                    ItemType = Enum.ItemType.Borrowable,
                    ItemCategoryId = 1,
                    WarehouseId = 1,
                    SupplierId = 1
                },
                new Item
                {
                    Id = 2,
                    Name = "Laptop Thinkpad",
                    Description = "Laptop Work Station tipe W-540",
                    TotalStocks = 20,
                    ItemType = Enum.ItemType.Borrowable,
                    ItemCategoryId = 2,
                    WarehouseId = 1,
                    SupplierId = 1,
                }
            );
            modelBuilder.Entity<Warehouse>().HasData(
                new Warehouse
                {
                    Id = 1,
                    Name = "Warehouse-01",
                    Address = "Danger Line 001",
                    UsedCapacity = 45,
                    TotalCapacity = 5000,
                }
            );
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier
                {
                    Id = 1,
                    Name = "Supplier-01",
                    Address = "Danger Line 001",
                    Description = "Seed Data",
                    Telephone = "08981216969",
                    Email = "supplier01@gmail.com",
                }
            );
        }
    }
}