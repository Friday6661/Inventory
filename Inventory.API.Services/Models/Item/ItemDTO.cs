using Inventory.API.Services.Models.ItemCategory;
using Inventory.API.Services.Models.Supplier;
using Inventory.API.Services.Models.Warehouse;

namespace Inventory.API.Services.Models.Item
{
    public class ItemDTO : BaseItemDTO
    {
        public int Id { get; set; }
    }
}