using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Services.Models.Transaction
{
    public abstract class BaseTransactionDTO
    {
        public int Quantity { get; set; }
        public int ItemId { get; set; }
        public int TransactionStatusId { get; set; }
    }
}