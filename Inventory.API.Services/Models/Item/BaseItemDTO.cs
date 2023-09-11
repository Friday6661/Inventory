using System.ComponentModel.DataAnnotations;
using Inventory.API.Data.Enum;

namespace Inventory.API.Services.Models.Item
{
    public abstract class BaseItemDTO
    {
        [Required(ErrorMessage = "Name is Required")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        public required string Description { get; set; }
        public int TotalStocks { get; set; }
        public bool IsDeleted { get; set; }
        public ItemType ItemType { get; set; }
        
        [Required(ErrorMessage = "ItemCategoryId is Required")]
        public int ItemCategoryId { get; set; }
        public int WarehouseId { get; set; }
        public int SupplierId { get; set; }
    }
}