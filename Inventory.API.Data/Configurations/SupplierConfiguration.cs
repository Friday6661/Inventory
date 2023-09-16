using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.API.Data.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasData(
                new Supplier
                {
                    Id = 1,
                    Name = "Supplier-01",
                    Address = "Danger Line 001",
                    Description = "Seed Data",
                    Telephone = "08981216969",
                    Email = "supplier01@gmail.com",
                }
            );
        }
    }
}