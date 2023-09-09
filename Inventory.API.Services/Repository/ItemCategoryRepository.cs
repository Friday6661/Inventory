using Inventory.API.Data;
using Inventory.API.Services.Contracts;
using Inventory.API.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Services.Repository
{
    public class ItemCategoryRepository : GenericRepository<ItemCategory>, IItemCategoriesRepository
    {
        private readonly InventoryDbContext _context;
        public ItemCategoryRepository(InventoryDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ItemCategory> GetDetails(int id)
        {
            var itemCategory = await _context.ItemCategories.Include(ic => ic.Items).FirstOrDefaultAsync(ic => ic.Id == id);
            if (itemCategory == null)
            {
                throw new NotFoundException(nameof(GetDetails), id);
            }
            return itemCategory;
        }

        public async Task SoftDeleteAsync(int id)
        {
            var itemCategory = await GetAsync(id);
            if (itemCategory == null)
            {
                throw new NotFoundException(nameof(SoftDeleteAsync), id);
            }
            itemCategory.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }
}