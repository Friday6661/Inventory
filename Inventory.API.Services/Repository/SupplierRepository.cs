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
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        private readonly InventoryDbContext _context;
        public SupplierRepository(InventoryDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Supplier> GetDetails(int id)
        {
            var supplier = await _context.Suppliers.Include(s => s.Items)
                                                    .FirstOrDefaultAsync(s => s.Id == id);
            if (supplier == null)
            {
                throw new NotFoundException(nameof(GetDetails), id);
            }
            return supplier;
        }

        public async Task SoftDeleteAsync(int id)
        {
            var supplier = await GetAsync(id);
            if (supplier == null)
            {
                throw new NotFoundException(nameof(SoftDeleteAsync), id);
            }
            supplier.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }
}