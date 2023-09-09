using System.ComponentModel.DataAnnotations.Schema;
using Inventory.API.Data.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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


        [ForeignKey(nameof(ItemCategoryId))]
        public int ItemCategoryId { get; set; }
        public ItemCategory ItemCategory { get; set; }
    }
}