using Inventory.API.Data;

namespace Inventory.API.Services.Contracts
{
    public interface IItemCategoriesRepository : IGenericRepository<ItemCategory>
    {
        Task<ItemCategory> GetDetails(int id);
        Task SoftDeleteAsync(int id);
    }
}