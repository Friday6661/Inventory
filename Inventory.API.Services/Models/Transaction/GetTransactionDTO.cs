using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Services.Models.Transaction
{
    public class GetTransactionDTO : BaseTransactionDTO
    {
        public int Id { get; set; }
    }
}