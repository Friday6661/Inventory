using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.API.Data.Configurations
{
    public class TransactionStatusConfiguration : IEntityTypeConfiguration<TransactionStatus>
    {
        public void Configure(EntityTypeBuilder<TransactionStatus> builder)
        {
            builder.HasData(
                new TransactionStatus
                {
                    Id = 1,
                    Name = "Pending Approval",
                    Description = "Transactions need to be approved by admin"
                },
                new TransactionStatus
                {
                    Id = 2,
                    Name = "Approved",
                    Description = "Transactions have been approved"
                },
                new TransactionStatus
                {
                    Id = 3,
                    Name = "Rejected",
                    Description = "Transactions have been rejected"
                },
                new TransactionStatus
                {
                    Id = 4,
                    Name = "Cancelled",
                    Description = "Transactions have been cancelled"
                },
                new TransactionStatus
                {
                    Id = 5,
                    Name = "Out on Loan",
                    Description = "Item is currently on loan to a user"
                },
                new TransactionStatus
                {
                    Id = 6,
                    Name = "Returned",
                    Description = "Transactions have been returned"
                },
                new TransactionStatus
                {
                    Id = 7,
                    Name = "Returned With Issue",
                    Description = "Transactions have been returned with issue"
                },
                new TransactionStatus
                {
                    Id = 8,
                    Name = "Consumed",
                    Description = "Item has been consumed"
                }
            );
        }
    }
}