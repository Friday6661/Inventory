using System.ComponentModel.DataAnnotations;

namespace Inventory.API.Data
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        
        [Required]
        [DataType(DataType.PhoneNumber)]
        public long Telephone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}