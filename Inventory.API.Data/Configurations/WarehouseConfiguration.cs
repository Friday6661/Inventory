using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.API.Data.Configurations
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasData(
                new Warehouse
                {
                    Id = 1,
                    Name = "Warehouse-01",
                    Address = "Danger Line 001",
                    UsedCapacity = 45,
                    TotalCapacity = 5000,
                }
            );
        }
    }
}