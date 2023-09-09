using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.API.Data.Enum;

namespace Inventory.API.Services.Models.Item
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalStocks { get; set; }
        public bool IsDeleted { get; set; }
        public ItemType ItemType { get; set; }
        public int ItemCategoryId { get; set; }
    }
}