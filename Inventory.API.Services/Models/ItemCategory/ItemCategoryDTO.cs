using Inventory.API.Services.Models.Item;
using Inventory.API.Services.Models.ItemCategory;

namespace Inventory.API.Services.Models.ItemCategoryDTO
{
    public class ItemCategoryDTO : BaseItemCategoryDTO
    {
        public int Id { get; set; }
        public ICollection<ItemDTO>? Items { get; set; }
    }
}