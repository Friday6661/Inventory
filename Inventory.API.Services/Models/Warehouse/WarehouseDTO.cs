using Inventory.API.Services.Models.Item;

namespace Inventory.API.Services.Models.Warehouse
{
    public class WarehouseDTO : BaseWarehouseDTO
    {
        public int Id { get; set; }
        public ICollection<ItemDTO> Items { get; set; }
    }
}