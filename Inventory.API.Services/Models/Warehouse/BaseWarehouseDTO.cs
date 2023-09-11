namespace Inventory.API.Services.Models.Warehouse
{
    public abstract class BaseWarehouseDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int UsedCapacity { get; set; }
        public int TotalCapacity { get; set; }
        public bool IsDeleted { get; set; }
    }
}