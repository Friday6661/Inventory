using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }

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
                    ItemCategoryId = 1
                },
                new Item
                {
                    Id = 2,
                    Name = "Laptop Thinkpad",
                    Description = "Laptop Work Station tipe W-540",
                    TotalStocks = 20,
                    ItemType = Enum.ItemType.Borrowable,
                    ItemCategoryId = 2
                }
            );
        }
    }
}