namespace Inventory.API.Data
{
    public class ItemCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<Item> Items { get; set; }
    }
}