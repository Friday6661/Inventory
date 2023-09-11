using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.API.Data;
using Inventory.API.Services.Contracts;
using Inventory.API.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Services.Repository
{
    public class WarehouseRepository : GenericRepository<Warehouse>, IWarehouseRepository
    {
        private readonly InventoryDbContext _context;
        public WarehouseRepository(InventoryDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Warehouse> GetDetails(int id)
        {
            var warehouse = await _context.Warehouses.Include(w => w.Items)
                                                        .FirstOrDefaultAsync(w => w.Id == id);
            if (warehouse == null)
            {
                throw new NotFoundException(nameof(GetDetails), id);
            }
            return warehouse;
        }

        public async Task SoftDelete(int id)
        {
            var warehouse = await GetAsync(id);
            if (warehouse == null)
            {
                throw new NotFoundException(nameof(SoftDelete), id);
            }
            warehouse.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }
}