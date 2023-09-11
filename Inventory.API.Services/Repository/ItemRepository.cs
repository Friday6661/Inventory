using Inventory.API.Data;
using Inventory.API.Services.Contracts;
using Inventory.API.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Services.Repository
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        private readonly InventoryDbContext _context;
        public ItemRepository(InventoryDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Item> GetDetails(int id)
        {
            var item = await _context.Items.Include(i => i.ItemCategory)
                                            .Include(i => i.Supplier)
                                            .Include(i => i.Warehouse)
                                            .FirstOrDefaultAsync(i => i.Id == id);
            if (item == null)
            {
                throw new NotFoundException(nameof(GetDetails), id);
            }
            return item;
        }

        public async Task SoftDeleteAsync(int id)
        {
            var item = await GetAsync(id);
            if (item == null)
            {
                throw new NotFoundException(nameof(SoftDeleteAsync), id);
            }
            item.IsDeleted = true;
            await _context.SaveChangesAsync();
            
        }
    }
}