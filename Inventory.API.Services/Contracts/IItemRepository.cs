using Inventory.API.Data;

namespace Inventory.API.Services.Contracts
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        Task<Item> GetDetails(int id);
        Task SoftDeleteAsync(int id);
    }
}