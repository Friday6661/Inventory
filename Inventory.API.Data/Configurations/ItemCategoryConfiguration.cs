using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.API.Data.Configurations
{
    public class ItemCategoryConfiguration : IEntityTypeConfiguration<ItemCategory>
    {
        public void Configure(EntityTypeBuilder<ItemCategory> builder)
        {
            builder.HasData(
                new ItemCategory
                {
                    Id = 1,
                    Name = "Monitor",
                    Description = "Ini adalah item yang memiliki Category Monitor"
                },
                new ItemCategory
                {
                    Id = 2,
                    Name = "Laptop",
                    Description = "Ini adalah item yang memiliki Category Laptop"
                }
            );
        }
    }
}