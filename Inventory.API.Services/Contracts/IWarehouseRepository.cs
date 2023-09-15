using Inventory.API.Data;

namespace Inventory.API.Services.Contracts
{
    public interface IWarehouseRepository : IGenericRepository<Warehouse>
    {
        Task<Warehouse> GetDetails(int id);
        Task SoftDelete(int id);
        Task UpdateUsedCapacityWarehouses();
    }
}