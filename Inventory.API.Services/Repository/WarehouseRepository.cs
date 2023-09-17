using AutoMapper;
using Inventory.API.Data;
using Inventory.API.Services.Contracts;
using Inventory.API.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Services.Repository
{
    public class WarehouseRepository : GenericRepository<Warehouse>, IWarehouseRepository
    {
        private readonly InventoryDbContext _context;
        private readonly IMapper _mapper;
        public WarehouseRepository(InventoryDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public async Task UpdateUsedCapacityWarehouses()
        {
            try
            {
                var warehouses = await GetAllAsync();
                foreach (var warehouse in warehouses)
                {
                    int totalStocksInWarehouse = warehouse.Items.Sum(item => item.TotalStocks);
                    warehouse.UsedCapacity = totalStocksInWarehouse;
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}