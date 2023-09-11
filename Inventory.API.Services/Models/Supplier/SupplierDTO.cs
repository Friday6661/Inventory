using Inventory.API.Services.Models.Item;

namespace Inventory.API.Services.Models.Supplier
{
    public class SupplierDTO : BaseSupplierDTO
    {
        public int Id { get; set; }
        public ICollection<ItemDTO> Items { get; set; }
    }
}