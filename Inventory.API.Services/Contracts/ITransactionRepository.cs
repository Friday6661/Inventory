using Inventory.API.Data;

namespace Inventory.API.Services.Contracts
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        Task<Transaction> GetDetails(int id);
        Task SoftDeleteAsync(int id);
    }
}