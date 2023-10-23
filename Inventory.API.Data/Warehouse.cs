namespace Inventory.API.Data
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int UsedCapacity { get; set; }
        public int TotalCapacity { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<Item> Items { get; set; }
    }
}