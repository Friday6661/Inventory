using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.API.Data
{
    public class Transaction
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }
        public ApiUser ApiUser { get; set; }
    }
}