using AutoMapper;
using Inventory.API.Data;
using Inventory.API.Services.Contracts;
using Inventory.API.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using Transaction = Inventory.API.Data.Transaction;

namespace Inventory.API.Services.Repository
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        private readonly InventoryDbContext _context;
        private readonly IMapper _mapper;
        public TransactionRepository(InventoryDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Transaction> GetDetails(int id)
        {
            var transaction = await _context.Transactions.FirstOrDefaultAsync(t => t.Id == id);
            if (transaction == null)
            {
                throw new NotFoundException(nameof(GetDetails), id);
            }
            return transaction;
        }

        public Task SoftDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
        
    }
}