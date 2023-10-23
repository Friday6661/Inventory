using System.ComponentModel.DataAnnotations;

namespace Inventory.API.Data
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<Item> Items { get; set; }
    }
}