using Inventory.API.Data;

namespace Inventory.API.Services.Contracts
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        Task<Item> GetDetails(int id);
        Task SoftDeleteAsync(int id);
        Task<Item> AddItemAndUpdateWarehouse(Item item);
        Task<Item> SoftDeleteAndUpdateWarehouse(Item item);
        Task EditItemAsync(Item item);
    }
}