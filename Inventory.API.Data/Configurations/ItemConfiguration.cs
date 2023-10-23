using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.API.Data.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasData(
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
        }
    }
}