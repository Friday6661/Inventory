using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Data
{
    public class TransactionItemConsume
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey(nameof(TransactionId))]
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }

        [ForeignKey(nameof(ItemId))]
        public int ItemId { get; set; }
        public Item Item { get; set; }

        [ForeignKey(nameof(TransactionStatusId))]
        public int TransactionStatusId { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
    }
}