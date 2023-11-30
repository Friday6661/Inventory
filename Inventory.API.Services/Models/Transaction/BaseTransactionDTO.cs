using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Services.Models.Transaction
{
    public abstract class BaseTransactionDTO
    {
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int UserId { get; set; }
    }
}