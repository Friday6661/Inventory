using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.API.Data
{
    public class Transaction
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        [ForeignKey(nameof(ItemId))]
        public int ItemId { get; set; }
        public Item Item { get; set; }

        [ForeignKey(nameof(TransactionStatusId))]
        public int TransactionStatusId { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
    }
}