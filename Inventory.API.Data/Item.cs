using System.ComponentModel.DataAnnotations.Schema;
using Inventory.API.Data.Enum;

namespace Inventory.API.Data
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalStocks { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ItemType ItemType { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;


        [ForeignKey(nameof(ItemCategoryId))]
        public int ItemCategoryId { get; set; }
        public ItemCategory ItemCategory { get; set; }

        [ForeignKey(nameof(WarehouseId))]
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}