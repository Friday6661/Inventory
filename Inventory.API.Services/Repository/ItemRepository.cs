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

        public async Task<Item> AddItemAndUpdateWarehouse(Item item)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var warehouse = await _context.Warehouses.FirstOrDefaultAsync(w => w.Id == item.WarehouseId);

                    if (warehouse != null)
                    {
                        int totalStocks = item.TotalStocks;
                        if (warehouse.UsedCapacity + totalStocks > warehouse.TotalCapacity)
                        {
                            transaction.Rollback();
                            throw new Exception("Used capacity exceeds maximum capacity.");
                        }

                        warehouse.UsedCapacity += totalStocks;
                        await _context.SaveChangesAsync();

                        await _context.AddAsync(item);
                        await _context.SaveChangesAsync();

                        transaction.Commit();
                    }
                    else
                    {
                        throw new NotFoundException(nameof(AddItemAndUpdateWarehouse), item);
                    }
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
                return item;
            }
        }
    }
}