using Inventory.API.Data;

namespace Inventory.API.Services.Contracts
{
    public interface ISupplierRepository : IGenericRepository<Supplier>
    {
        Task<Supplier> GetDetails(int id);
        Task SoftDeleteAsync(int id);
    }
}